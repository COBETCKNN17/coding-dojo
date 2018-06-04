function minHeapInsert(arr, val){
    arr.push(val);
    var thischild = arr[arr.length-1];
    while (thischild.value < thischild.parent.value){
        temp = thischild.index;
        thischild.index = thischild.parent.index;
        thischild.parent.index = temp;
    }
}

minHeapInsert([2,3,4,5], 1)

// Not sure if this works. I'm assuming that a parent and index were both assigned during the construction of the heap like with nodes. Can I just treat it like a normal array instead? Need to revisit this.