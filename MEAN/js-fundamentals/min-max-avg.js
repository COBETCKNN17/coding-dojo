function maxMinAvg(arr) {
	var x = 0;
	var max = arr[x];
	var min = arr[x];
	var sum = 0;

	while (x < arr.length){
	if (arr[x] < min){
		min = arr[x];
	}

	if (arr[x] > max){
		max = arr[x];
	}

	sum = sum+arr[x];

	x++;

	}

var avg = sum/arr.length;
var arrnew = [max,min,avg];

return arrnew;

}