var mongoose = require('mongoose');

var ProductSchema = new mongoose.Schema({
    title: { type: String},
    price: {type:Number},
    image: {type: String},
}, {timestamp:true});

module.exports = mongoose.model('Product', ProductSchema); 
var Product = mongoose.model('Product');