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
                    return;
                }
                else {
                    walker = walker.right;
                }
            }

            if (walker.value >= val) {
                if (!walker.left) {
                    walker.left = new Node(val);
                    return;
                }
                else {
                    walker = walker.left;
                }
            }
        }
    }
}

var first = new BST();
first.root = new Node(30);
first.root.right = new Node(50);
first.root.left = new Node(10);
first.insert(22);
first.insert(200);
first.insert(32);
first.insert(65);

console.log(first);