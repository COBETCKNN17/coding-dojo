var express = require('express');
var app = express();
var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/mongoose_dashboard');
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));
var path = require('path');
app.use(express.static(path.join(__dirname, './static')));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Schema

var ChinchillaSchema = new mongoose.Schema({
    name: String,
    color: String,
    age: String,
}, { timestamps: true });

mongoose.model('Chinchilla', ChinchillaSchema);
var Chinchilla = mongoose.model('Chinchilla');

// Index Route

app.get('/', function (req, res) {

    Chinchilla.find({}, function (err, chinchillas) {
        if (err) { console.log(err); }
        else {
            var data = {};
            data['chinchillas'] = chinchillas;
            res.render('index', data);
        }
    });

});

// New Chinchilla Form

app.get('/new', function (req, res) {
    res.render('new');
});

// Single Chinchilla Show

app.get('/:id', function (req, res) {
    Chinchilla.find({ _id: req.params.id }, function (err, response) {
        if (err) { console.log(err); }
        res.render('show', { chinchilla: response[0] });
    });
});

// New Chinchilla Creation Processing

app.post('/create', function (req, res) {

    var chinchilla = new Chinchilla({ name: req.body.name, color: req.body.color, age: req.body.age });

    chinchilla.save(function (err) {
        if (err) { console.log(err); }
        res.redirect('/');
    });

});

// Chinchilla Edit Page

app.get('/edit/:id', function (req, res) {

    Chinchilla.find({ _id: req.params.id }, function (err, chinchillas) {
        if (err) { console.log(err); }
        else {
            Chinchilla.find({ _id: req.params.id }, function (err, response) {
                if (err) { console.log(err); }
                res.render('edit', { chinchilla: response[0] });
            })
        };
    });

});

// Chinchilla Update

app.post('/update/:id', function (req, res) {

    Chinchilla.update({ _id: req.params.id }, { name: req.body.name, color: req.body.color, age: req.body.age }, function (err) {
        if (err) { console.log(err); }
        res.redirect('/');
    });

});

// Delete Chinchilla

app.get('/delete/:id', function (req, res) {

    Chinchilla.remove({ _id: req.params.id }, function (err) {
        if (err) { console.log(err); }
        res.redirect('/');
    });

});

// Setting our Server to Listen on Port: 8000
app.listen(8000, function () {
    console.log("listening on port 8000");
})