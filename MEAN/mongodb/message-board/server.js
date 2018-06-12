var express = require('express');
var app = express();
var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/message_board');
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));
var path = require('path');
app.use(express.static(path.join(__dirname, './static')));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Schemas

var Schema = mongoose.Schema;

var MessageSchema = new mongoose.Schema({
	name: String,
	message: String,
	comments: [{ type: Schema.Types.ObjectId, ref: 'Comment' }]
});

var CommentSchema = new mongoose.Schema({
	_message: { type: Schema.Types.ObjectId, ref: 'Message' },
	name: String,
	comment: String,
	created_at: { type: Date, default: new Date }
});

mongoose.model('Message', MessageSchema);
var Message = mongoose.model('Message');

MessageSchema.path('name').required(true, 'Name cannot be blank!');
MessageSchema.path('message').required(true, 'Messages cannot be blank!');

mongoose.model('Comment', CommentSchema);
var Comment = mongoose.model('Comment');

CommentSchema.path('name').required(true, 'Name cannot be blank!');
CommentSchema.path('comment').required(true, 'Comments cannot be blank!');

// Index Route

app.get('/', function (req, res) {

	Message.find({}).populate('comments').exec(function (err, messages) {
		res.render('index', { messages: messages });
	});

});

// Message Post

app.post('/message', function (req, res) {
	var message = new Message({ name: req.body.name, message: req.body.message });
	message.save(function (err) {
		if (err) {
			var errors = message.errors;
			Message.find({}).populate('comments').exec(function (err, messages) {
				res.render('index', { messages: messages, errors: errors });
			});
		} else {
			res.redirect('/');
		}
	});
});

// Comment Post

app.post('/comment/:id', function (req, res) {
	Message.findOne({ _id: req.params.id }, function (err, message) {
		var comment = new Comment(req.body);
		comment._message = message._id;
		message.comments.push(comment);
		comment.save(function (err) {
			message.save(function (err1) {
				if (err) {
					console.log('Error');
					Message.find({}).populate('comments').exec(function (err2, messages) {
						res.render('index', { messages: messages, errors: comment.errors })
					})
				} else {
					res.redirect('/');
				}
			});
		});
	});
});

// Setting our Server to Listen on Port: 8000
app.listen(8000, function () {
	console.log("listening on port 8000");
})