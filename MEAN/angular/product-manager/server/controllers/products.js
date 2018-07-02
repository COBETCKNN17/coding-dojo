const mongoose = require('mongoose');
var Product = require('../models/product');

function handler(res) {
    return function(err, result) {
        if(err) {
            res.json({
                message: "Error",
                error: err
            });
        }
        else {
            res.json({
                message: "Success",
                data: result
            });
        }
    }
}

module.exports = {
    index: function(req, res) {
        Product.find({}, handler(res));
    },

    create: function (req, res) {
        Product.create({ title: req.body.title, price: req.body.price, image: req.body.image }, function (err, product) {
            if (err){
                console.log("Error:", err);
                res.json(err);
            }
            else{
                console.log("It worked!");
                res.redirect('/');
            }
        });
    },

        update: function (req, res) {
            Product.findOne({ _id: req.params.id }, function (err, product) {
                var product_obj = {};
                if (req.body.title) {
                    product_obj['title'] = req.body.title;
                }
                if (req.body.price) {
                    product_obj['price'] = req.body.price;
                }
                if (req.body.image) {
                    product_obj['image'] = req.body.image;
                }
                product_obj['updated_at'] = Date.now();
                Product.update({ _id: req.params.id }, {
                    $set: product_obj
                }, function (err, product) {
                    if (err) {
                        console.log("Error:", err);
                        res.json(err);
                    } else {
                        console.log("Updated Product!");
                        res.json({ message: "Updated Product!", data: product });
                    }
                })
            })
        },

    delete: function (req, res) {
        Product.remove({ _id: req.params.id }, function (err, product) {
            if (err) {
                console.log("Error:", err);
                res.json(err);
            }
            else{
                console.log("Product has been deleted!");
                res.json(product);
            }
        });
    },

    show: function(req, res) {
        Product.findById(req.params.id, handler(res));
    }

}