var tasks = require('./../controllers/tasks.js');
module.exports = function (app) {
    app.get('/', function (req, res) {
        tasks.show(req, res);
    });
    app.post('/new', function (req, res) {
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