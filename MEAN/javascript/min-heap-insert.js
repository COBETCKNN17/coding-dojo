// Not sure if this works. I'm assuming that a parent and index were both assigned during the construction of the heap like with nodes. Can I just treat it like a normal array instead? Need to revisit this.

function minHeapInsert(arr, val){
    arr.push(val);
    var thischild = arr[arr.length];
    while (thischild.value < thischild.parent.value){
        temp = thischild.index;
        thischild.index = thischild.parent.index;
        thischild.parent.index = temp;
    }
}

minHeapInsert([2,3,4,5], 1)

// Assuming it works like a normal array:

function minHeapInsertNew(arr, val){
    arr.push(val);
    var current = arr.length;
    while (arr[current] < arr[current-1]){
        temp = arr[current];
        arr[current] = arr[current-1];
        arr[current-1] = temp;
        current--;
    }
  console.log(arr);
}

minHeapInsertNew([2,3,4,5], 1)