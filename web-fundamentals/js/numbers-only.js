function numbersOnly(arr){
    newArr = [];

    for (var x = 0; x < arr.length; x++){
        if (typeof arr[x] === "number"){
            newArr.push(arr[x]);
        }
    }

    console.log(newArr);
    return newArr;
}

numbersOnly([1, "apple", -3, "orange", 0.5]);