var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var TaskSchema = new Schema({
    title: {type: String, required:true, minlength:2, maxlength:255},
    description: {type: String, default:""},
    completed: {type: Boolean,default:false}
    },{timestamps: true});

mongoose.model('Task', TaskSchema);