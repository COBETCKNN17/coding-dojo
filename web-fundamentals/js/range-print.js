function printRange(start,end,skip){
    var count = 0;

    if(skip == null){
        skip = 1;
    }

    if(end == null){
        end = start;
        start = 0;
    }

    console.log(start);

    for (var x = start+1; x < end; x++){
        count++;
        if (count == skip){
            console.log(x);
            count = 0;
        }
    }
}

printRange(2,10,2);