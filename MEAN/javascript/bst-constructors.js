function BST() {
    this.root = null;
}

function Node(val) {
    this.value = val;
    this.left = null;
    this.right = null;
}

BST.prototype.insert = function (val) {
    if (!this.root) {
        this.root = new Node(val);
        return;
    }
    else {
        var walker = this.root;
        while (walker) {
            if (walker.value < val) {
                if (!walker.right) {
                    walker.right = new Node(val);
                    return this;
                }
                else {
                    walker = walker.right;
                }
            }

            if (walker.value >= val) {
                if (!walker.left) {
                    walker.left = new Node(val);
                    return this;
                }
                else {
                    walker = walker.left;
                }
            }
        }
    }
}

BST.prototype.postOrder = function () {
    var tree = [this.root];
    var reverseTree = [];
    while (tree.length) {
        var current = tree.pop();
        reverseTree.push(current);

        if (current.left) {
            tree.push(current.left);
        }
        if (current.right) {
            tree.push(current.right);
        }
    }
    for (var i = reverseTree.length - 1; i >= 0; i--) {
        console.log(reverseTree[i].value);
    }
}

BST.prototype.preOrder = function () {
    var tree = [this.root];

    while (tree.length) {
        var current = tree.pop();
        console.log(current.value)
        if (current.right) {
            tree.push(current.right);
        }
        if (current.left) {
            tree.push(current.left);
        }
    }
}

BST.prototype.inOrder = function(){
    var tree = [this.root];
    while (tree.length) {
        var current = tree.pop();
        if (current.left && !current.left.visited) {
            tree.push(current);
            tree.push(current.left);
        } 
        else {
            current.visited = true;
            console.log(current.value);
            if (current.right) {
                tree.push(current.right);
            }
        }
    }
}


var first = new BST();
first.root = new Node(40);
first.insert(20).insert(25).insert(50);

console.log(first);

first.postOrder();
console.log("---");
first.preOrder();
console.log("---");
first.inOrder();