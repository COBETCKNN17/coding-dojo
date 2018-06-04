// Need to revise to compare multiple children.

function minHeapRemove(arr){
    temp = arr[1];
    arr[1] = arr[arr.length];
    arr[arr.length] = temp;
    arr.pop();

    var element = arr[1];
    while (element.value > element.child.value){
        temp = element.index;
        element.index = element.child.index;
        element.child.index = temp;
    }
}

minHeapRemove([2,3,4,5])