var products = require('../controllers/products');
var path = require('path')

module.exports = function(app){
    app.get("/api/products", products.index);
    app.get("/api/products/:id", products.show);
    app.put("/api/products/:id", products.update);
    app.post("/api/products", products.create);
    app.delete("/api/products/:id/delete", products.delete);
    app.all("*", (req,res) => {
        res.sendFile(path.resolve("./public/dist/public/index.html"))
    });
}