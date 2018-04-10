/// Get 1 to 255

function get_array() {
	var arr = [];
	var x = 1;

	while(arr.length <255){
	arr.push(x);
	x++;
	}
	return arr;
}

/// Get even 1000

function sum_even_numbers() {
	var sum = 0;

	for (var num = 1; num < 1001; num++){
		if (num % 2 === 0){
		sum += num;
		}
	}
	return sum;
}

/// Sum odd 5000
	
	function sum_odd_5000() {
		var sum = 0;

		for (var num = 1; num < 5001; num++){
			if (num % 2 == 1){
				sum += num;
			}
		}
		return sum;
	}

/// Interate an Array

function iterArr(arr) {
	var sum = 0;
	var x = 0;

	while (x < arr.length){
	sum = sum+arr[x];
	x++;
	}
	return sum;
}

/// Find max

function findMax(arr) {
	var max = 0;
	var x = 0;

	while (x < arr.length){
	if (arr[x] > max){
		max = arr[x];
		x++;
		}
	}
	return max;
}


/// Find average

function findAvg(arr) {
	var avg = 0;
	var x = 0;
	var sum = 0;

	while (x < arr.length){
	sum = sum+arr[x];
	x++;
	}
	
	avg = sum/arr.length;
	
	return avg;
}


/// Array odd

function oddNumbers() {
	var arr = [];
	
	for (var num = 1; num <51;){
	if (num % 2 === 0){
	}

	else{
	arr.push(num);
	}

	num++;
	}
	
	return arr;
}

/// Greater than Y

function greaterY(arr,Y) {
	var count = 0;
	var x = 0;

	while (x < arr.length){
	if (arr[x] > Y){
		count = count+1;
		}
	x++;
	}
	
	return count;


}

/// Squares

function squareVal(arr) {
	var x = 0;	

	while (x < arr.length){
	arr[x] = arr[x]*arr[x];
	x++;
	}
	
	return arr;

}

/// Negatives

function noNeg(arr) {
	var x = 0;

	while (x < arr.length){
		if (arr[x]<0){
		arr[x] = 0;
		}
		x++;
		}
	return arr;
}

/// Min/Max/Avg

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

/// Swap Values

function swap(arr) {

	var temp = arr[0];
	arr[0] = arr[arr.length - 1];
	arr[arr.length - 1] = temp;

return arr; /// forget stupid newarr thing

}

/// Number to string

function numToStr (arr) {
	var x = 0;

	while (x < arr.length){
		if (arr[x] < 0){
			arr[x] = 'Dojo';
		}
	x++;
	}
	return arr;
}