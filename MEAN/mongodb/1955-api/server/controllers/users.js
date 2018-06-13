var mongoose=require("mongoose");
var User = mongoose.model('User');

module.exports = {
    show:function(req,res){
        User.find({},function(err,users){
            res.json(users);
        });
    },
    new:function(req,res){
        User.create({name: req.params.name},function(err,user){
            res.redirect('/');
        });
    },
    remove: function(req,res){
        User.remove({name: req.params.name},function(err,user){
            if(err)
                res.json(err);
            else
                res.json(user);
        });
    },
};