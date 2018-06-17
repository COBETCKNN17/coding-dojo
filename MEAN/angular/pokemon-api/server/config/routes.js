var tasks = require('./../controllers/tasks.js');
module.exports = function (app) {
    app.get('/tasks', function (req, res) {
        tasks.show(req, res);
    });
    app.post('/tasks/new', function (req, res) {
        tasks.new(req, res);
    });
    app.delete('/tasks/:id', function (req, res) {
        tasks.remove(req, res);
    });
    app.get('/tasks/:id', function (req, res) {
        tasks.showone(req,res);
    });
    app.put('/tasks/:id', function (req, res) {
        tasks.update(req,res);
    });
};