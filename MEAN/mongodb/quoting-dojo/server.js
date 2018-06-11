var express = require('express');
var app = express();
var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/quoting_dojo');
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));
var path = require('path');
app.use(express.static(path.join(__dirname, './static')));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Schema

var QuoteSchema = new mongoose.Schema({
    name: String, 
    quote: String,
}, { timestamps: true });

mongoose.model('Quote', QuoteSchema);
var Quote = mongoose.model('Quote');

// Routes

app.get('/', function(req, res){
    res.render('index');
});

app.get('/quotes', function(req, res){
    Quote.find({}, function(err, quotes){
        if(err){
            console.log("Error! Quote not submitted.")
            res.render('index');
            }
        else {
            res.render('quotes', {quotes: quotes});
        }
    });
})

app.post('/quotes', function(req, res){
    console.log(req.body);
    const quote = new Quote({name: req.body.name, quote: req.body.quote});
    quote.save(function(err){
        if(err) {
            console.log('Error! Quote not submitted.');
        } 
        else { console.log('Quote has been added.');
        }
        res.redirect('/');
        });   
    });


// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})