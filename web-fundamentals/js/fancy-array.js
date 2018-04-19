function fancyArray(symbol,reversed){
    var arr = ["James", "Jill", "Jane", "Jack"];

    if (symbol == null){
        symbol = ">";
    }

    if (reversed == null){
        reversed = false;
    }

    if(reversed == false){
        for (var x = 0; x < arr.length; x++){
            console.log(x, symbol, arr[x]);
        }
    }
    if (reversed == true){
        for (var x = arr.length-1; x >= 0; x--){
            console.log(x, symbol, arr[x]);
        }
    }
}

fancyArray("=>",true);