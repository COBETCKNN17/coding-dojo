var mongoose = require("mongoose");
var Task = mongoose.model('Task');

module.exports = {
    show: function (req, res) {
        Task.find({}, function (err, tasks) {
            if (err){
                console.log("Error:", err);
                res.json(err);
            }
            else{
            res.json(tasks);
            }
        });
    },
    new: function (req, res) {
        Task.create({ title: req.body.title, description: req.body.description, completed: req.body.completed }, function (err, task) {
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
    remove: function (req, res) {
        Task.remove({ _id: req.params.id }, function (err, task) {
            if (err) {
                console.log("Error:", err);
                res.json(err);
            }
            else{
                console.log("Task has been deleted!");
                res.json(task);
            }
        });
    },
    showone: function (req, res) {
        Task.findOne({ _id: req.params.id }, function (err, task) {
            if (err) {
                console.log("Error:", err);
                res.json(err);
            } else {
                console.log("It worked!");
                res.json(task);
            }
        })
    },
    update: function (req, res) {
        Task.findOne({ _id: req.params.id }, function (err, task) {
            var task_obj = {};
            if (req.body.title) {
                task_obj['title'] = req.body.title;
            }
            if (req.body.description) {
                task_obj['description'] = req.body.description;
            }
            if (req.body.completed != null) {
                task_obj['completed'] = req.body.completed;
            }
            task_obj['updated_at'] = Date.now();
            Task.update({ _id: req.params.id }, {
                $set: task_obj
            }, function (err, task) {
                if (err) {
                    console.log("Error:", err);
                    res.json(err);
                } else {
                    console.log("Updated Task!");
                    res.json({ message: "Updated Task!", data: task });
                }
            })
        })
    },
};