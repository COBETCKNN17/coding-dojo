var mongoose = require('mongoose');
var Quote = mongoose.model('Quote');

module.exports = {
    show: function (req, res) {
        Quote.find({}, function (err, quotes) {
            if (err) {
                console.log("Error! Quote not submitted.")
                res.render('index');
            }
            else {
                res.render('quotes', { quotes: quotes });
            }
        });
    },
    create: function (req, res) {
        console.log(req.body);
        const quote = new Quote({ name: req.body.name, quote: req.body.quote });
        quote.save(function (err) {
            if (err) {
                console.log('Error! Quote not submitted.');
            }
            else {
                console.log('Quote has been added.');
            }
            res.redirect('/');
        });
    }
}