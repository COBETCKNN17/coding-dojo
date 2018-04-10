///////// Page 16

////// Setting and Swapping
// Set myNumber to 42. Set myName to your name. Now swap myNumber into myName & vice versa.

function setSwap(){
    var myNumber = 42;
    var myName = "Nat";
    var temp = null;

    var temp = myName;
    var myName = myNumber;
    var myNumber = temp;

    console.log(myName);
    console.log(myNumber);
}

setSwap();

////// Print -52 to 1066
// Print integers from -52 to 1066 using a FOR loop.

function neg52To1066(){

	for (var number = -52; number <= 1066; number++){
		console.log(number);
	}
}

neg52To1066();

////// Don't Worry, Be Happy
// Create beCheerful(). Within it, console.log string "good morning!" Call it 98 times.

function beCheerful(){
	var goodmorning = "good morning!";

	for (var times = 1; times <=98; times++){

			console.log(goodmorning);
	}

}

beCheerful();

////// Multiples of Three - but Not All
// Using FOR, print multiples of 3 from -300 to 0. Skip -3 and -6.

function multiplesOfThree(){
	var threeMultiple = -300;

	while (threeMultiple != -3 && threeMultiple != -6 && threeMultiple <=0){
		console.log(threeMultiple);
		threeMultiple = threeMultiple + 3;
	}
}

multiplesOfThree();

////// Printing Integers with While
// Print integers from 2000 to 5280, using a WHILE.

function printWithWhile(){
	var printwhile = 2000;

	while(printwhile <= 5280){
		console.log(printwhile);
		printwhile++;
	}

}

printWithWhile();

////// You Say It's Your Birthday
// If 2 given numbers represent your birth month and day in either order, log "How did you know?", 
// else log "Just another day...."

function yourBirthday(){
	var day = Math.floor((Math.random() * 31) + 1);
	var month = Math.floor((Math.random() *12) + 1);

	if ((day == 7 && month == 11) || (day == 11 && month == 7)) {
	console.log("How did you know?")
	}
	
	else {
	console.log("Just another day…")
	}

console.log(day,month);

}

yourBirthday();

////// Leap Year
// Write a function that determines whether a given year is a leap year. If a year is divisible by four,
// it is a leap year, unless it is divisible by 100. However, if it is divisible by 400, then it is.

function leapYear(){
	var year = Math.floor((Math.random() * 118) + 1900); /// Set a random year from 1900-2018

	console.log("Year = " +year);

	if (((year % 4 == 0) && (year % 100 !=0)) || (year % 400 == 0 )) { /// Leap year is either divisible by 4, but NOT 100 -- OR any year divisible by 400 is a leap year
	console.log("Yes! It is a Leap Year!");
	} 

	else {
	console.log("No. It is not a Leap Year.");
	}

}

leapYear();

////// Print and Count
// Print all integer multiples of 5, from 512 to 4096. Afterward, also log how many there were.


function printAndCount(){
	var counter = 0;
	var printCount = 512;

	while (printCount < 4097){
		if (printCount % 5 == 0) {
			console.log(printCount);
			counter++;
		}
		printCount++;
	}
	console.log("Total multiples of 5: " +counter);
}

printAndCount();

////// Multiples of Six
// Print multiples of 6 up to 60,000, using a WHILE.

function multiplesOfSix(){
	var multiSix = 6;

	while (multiSix <= 60000){
		if (multiSix % 6 == 0) {
			console.log(multiSix);
		}
	multiSix++;
	}
}

multiplesOfSix();

////// Counting the Dojo Way
// Print integers 1 to 100. If divisible by 5, print "Coding" instead. If by 10, also print " Dojo".

function dojoCounting(){
	var countdojo = 1;

	while (countdojo < 101){
		if (countdojo % 5 == 0 && countdojo % 10 != 0){
			console.log("Coding");
		}

		if (countdojo % 10 == 0){
			console.log("Dojo");
		}
		console.log(countdojo);
		countdojo++;
	}

}

dojoCounting();

////// What Do You Know?
// Your function will be given an input parameter incoming. Please console.log this value.

function whatDoYouKnow(incoming){
	var incomingVar = incoming;
	console.log(incomingVar);
}

whatDoYouKnow(123);

////// Woah, That Sucker's Huge
// Add odd integers from -300,000 to 300,000, and console.log the final sum. Is there a shortcut?

function suckersHuge(){
	suckerSum = 0;

	for (sucker = -300000; sucker < 300001; sucker++){
		if (sucker % 2 === 0){
		}
		else{
			suckerSum += sucker;
		}
	}
	console.log(suckerSum);
}

suckersHuge();

////// Countdown by Fours
// Log positive numbers starting at 2016, counting down by fours (exclude 0), without a FOR loop.

function countdownFours(){
	fourNumber = 2016;

	while (fourNumber >= 1){
		console.log(fourNumber);
		fourNumber = fourNumber - 4;
	}
}

countdownFours();

////// Flexible Countdown
// Based on earlier “Countdown by Fours”, given lowNum, highNum, mult, print multiples of mult
// from highNum down to lowNum, using a FOR. For (2,9,3), print 9 6 3 (on successive lines).

function flexiCountdown(lowNum, highNum, mult){

    while(highNum >= lowNum){ /// While value in the middle slot (highNum) is 
    	/// greater than or equal to the value in the first slot (lowNum)
        if(highNum % mult == 0){ /// Each time highNum is a multiple of the 3rd number (mult)
        	/// We console log highNum
            console.log(highNum);
        }
    highNum--; /// subtract 1 from highNum
    }
}

flexiCountdown(2, 9, 3);

////// The Final Countdown
// Given 4 parameters (param1,param2,param3,param4), print the multiples of param1, starting at param2 and extending 
// to param3. One exception: if a multiple is equal to param4, then skip (don’t print) it. Do this using a WHILE. 
// Given (3,5,17,9), print 6,12,15 (which are all of the multiples of 3 between 5 and 17, and excluding the value 9).

function finalCountdown(param1,param2,param3,param4){

    while(param2 <= param3){
        if (param2 % param1 == 0 && (param2 != 9 || param2 != param4)){
        	console.log(param2);
        	param2++;
        }
        else{
            param2++;
        }
    }
}

finalCountdown(3,5,17,9);

///////// Page 20

////// Countdown
// Create a function that accepts a number as an input. Return a new array that counts down by one, from
// the number (as array’s ‘zeroth’ element) down to 0 (as the last element). How long is this array? 

function countdown(countdownNumber){
	var countdownArray = [];
	var i = countdownNumber;
	while (i >= 0) {
			countdownArray.push(i);
			i--;
		}
	
	console.log(countdownArray);
	console.log("Array length: " +countdownArray.length);
}

countdown(8);

////// Print and Return
// Your function will receive an array with two numbers. Print the first value, and return the second. 

function printAndReturn(value1,value2){
	var printReturnArray = [value1,value2];

	console.log(printReturnArray[0]);
	return (printReturnArray[0]);

}

printAndReturn(7,14);

////// First Plus Length
// Given an array, return the sum of the first value in the array, plus the array’s length. 
// What happens if the array’s first value is not a number, but a string (like "what?") or a boolean 
// (like false).   

function firstPlusLength(value1,value2,value3){
	var firstPlusLengthArray = [value1,value2,value3];

	console.log(firstPlusLengthArray[0] + firstPlusLengthArray.length);
	return (firstPlusLengthArray[0] + firstPlusLengthArray.length);

}

firstPlusLength(14,3,9); /// If the first value is a string, it writes the string with the length number
// at the end. If the first value is a boolean, only the length is returned.

////// Values Greater than Second
// For [1,3,5,7,9,13], print values that are greater than its 2nd value. Return how many values this is. 

function greaterThanSecond(){
	var gtsArray = [1,3,5,7,9,13];
	var num = 0;
	var count = 0;

	while (num <= gtsArray.length){
		if (gtsArray[num] > gtsArray[1]){
			console.log(gtsArray[num]);
			count++;
			num++;
		}

		else{
			num++;
		}
	}
	console.log("Number of values greater than 2nd value: " +count);

}

greaterThanSecond();

////// Values Greater than Second, Generalized
// Write a function that accepts any array, and returns a new array with the array values that are greater
// than its 2nd value. Print how many values this is. What will you do if the array is only one element long?

function greaterThanSecondG(arr){
	var gtsgArray = arr;
	var num = 0;
	var count = 0;

	if (gtsgArray.length < 2){
		console.log("The array is too short!");
	}

	else{
		while (num <= gtsgArray.length){
			if (gtsgArray[num] > gtsgArray[1]){
				console.log(gtsgArray[num]);
				count++;
				num++;
			}

			else{
				num++;
			}
		}
		console.log("Number of values greater than 2nd value: " +count);
	}
}

greaterThanSecondG([3,7,5,3,2,8,9]);

////// This Length, That Value
// Given two numbers, return array of length num1 with each value num2. Print "Jinx!" if they are same.

function thisThat(num1,num2){
	var thisThatArray = [];
	var arrayLength = num1;

	while(thisThatArray.length < arrayLength){
		thisThatArray.push(num2);
	}

	if (num1 == num2) {
		console.log("Jinx!");
	}

	console.log(thisThatArray);
	return thisThatArray;
}

thisThat(8,2);

////// Fit the First Value
// Your function should accept an array. If value at [0] is greater than array’s length, print "Too big!";
// if value at [0] is less than array’s length, print "Too small!"; otherwise print "Just right!". 

function fitTheFirst(arr){
	var fitTheFirstArray = arr;

	if (fitTheFirstArray[0] > fitTheFirstArray.length) {
		console.log("Too big!");
	}

	else if (fitTheFirstArray[0] < fitTheFirstArray.length) {
		console.log("Too small!");
	}

	else if (fitTheFirstArray[0] == fitTheFirstArray.length) {
		console.log("Just right!");
	}

}

fitTheFirst([5,4,6,2,1]);

////// Fahrenheit to Celsius
// Kelvin wants to convert between temperature scales. Create fahrenheitToCelsius(fDegrees)
// that accepts a number of degrees in Fahrenheit, and returns the equivalent temperature as expressed
// in Celsius degrees. For review, Fahrenheit = (9/5 * Celsius) + 32

function fahrenheitToCelsius(celsius){

	celsius = celsius - 32;
	celsius = celsius * 5/9;

	console.log("Degrees in celcius: " +celsius);
	return celsius;

	}
fahrenheitToCelsius(53);

////// Celsius to Fahrenheit
// Create celsiusToFahrenheit(cDegrees) that accepts number of degrees Celsius, and returns
// the equivalent temperature expressed in Fahrenheit degrees.
// (optional) Do Fahrenheit and Celsius values equate at a certain number? Scientific calculation can be
// complex, so for this challenge just try a series of Celsius integer values starting at 200, going downward
// (descending), checking whether it is equal to the corresponding Fahrenheit value. 

function celsiusToFahrenheit(fahrenheit){

	fahrenheit = fahrenheit * 9/5;
	fahrenheit = fahrenheit + 32;

	console.log("Degrees in fahrenheit: " +fahrenheit);
	return fahrenheit;

	}
celsiusToFahrenheit(53);

///////// Page 22

////// Biggie Size
// Given an array, write a function that changes all positive numbers in the array to “big”. Example:
// makeItBig([-1,3,5,-5]) returns that same array, changed to [-1,"big","big",-5]. 

function biggieSize(arr) {
	for (var num = 0; num < arr.length; num++) {
		if(arr[num] < 0) {
			arr[num] = arr[num];
			} 
		else {
			arr[num] = "big";
			}
		}
	console.log(arr);
	return arr;
}

biggieSize([-3,4,5,8,33,1,-6,42,4,-14]);

////// Print Low, Return High
// Create a function that takes array of numbers. The function should print the lowest value in the 
// array, and return the highest value in the array.

function lowHigh(arr){
var lowNum = arr[0];
var highNum = arr[0];

	if (arr.length < 2) {
		console.log("The array needs more numbers!");
	} 

	else {
		for(var num = 0; num < arr.length; num++) {
			if (arr[num] > highNum){
				highNum = arr[num];
				}
			else if (arr[num] < lowNum){
				lowNum = arr[num];
			}
		}
	}
	console.log("Lowest number: " +lowNum);
	return highNum;
}

lowHigh([2,1,6,8,43,2,1,0]);


////// Print One, Return Another
// Build a function that takes array of numbers. The function should print second-to-last value in the
// array, and return first odd value in the array.

function oneAnother(arr){
var oddNumber = arr[0];

	if (arr.length < 2) {
		console.log("The array needs more numbers!");
	} 

	else {
		for (var num = 0; num < arr.length; num++) {
			if (arr[num] % 2 == 0) {
			}
			else {
				oddNumber = arr[num];
				break;
			}
		}
	}

	console.log(arr[arr.length-2]);
	return oddNumber;
}

oneAnother([2,22,3,8,43,2,1,0]);

////// Double Vision
// Given array, create a function to return a new array where each value in the original has been doubled. Calling double([1,2,3]) should
// return [2,4,6] without changing original.

function doubleVision(arr){
	var singleArray = arr;
	var doubleArray = [];

	for(var num = 0; num < arr.length; num++) {
		doubleArray.push((singleArray[num])*2);
	}

	console.log("Original Array: " +singleArray);
	console.log("Doubled Array: " +doubleArray);
}

doubleVision([1,2,3]);

////// Count Positives
// Given array of numbers, create function to replace last value with number of positive values.
// Example, countPositives([-1,1,1,1]) changes array to [-1,1,1,3] and returns it.

function countPositives(arr){

var positiveArray = arr;
var counter = 0;

	for(var num = 0; num < positiveArray.length; num++) {
		if (positiveArray[num] > 0){
			counter++;
		}
	}

	positiveArray[positiveArray.length-1] = counter;

console.log(positiveArray);

}

countPositives([-1,1,1,1]);

////// Evens and Odds
// Create a function that accepts an array. Every time that array has three odd values in a row,
// print "That’s odd!" Every time the array has three evens in a row, print "Even more so!"

function evenOdd(arr) {
	var oddCount = 0;
	var evenCount = 0;
	for (var num = 0; num < arr.length; num++) {
		if (arr[num] % 2 == 1) {
			oddCount++;
			if (oddCount == 3) {
			console.log("That's odd!");
			oddCount = 0;
			}
		}
		else {
			evenCount++;
			if (evenCount == 3) {
				console.log("Even more so!");
				evenCount = 0;
			}
		}
	}
}

evenOdd([1,1,1,2,2,2,2,3,2,2,2,1,1,1]);

////// Increment the Seconds
// Given arr, add 1 to odd elements ([1], [3], etc.), console.log all values and return arr. 

function incrementTheSeconds(arr){

	for (var num = 0; num < arr.length; num++) {
		if (num % 2 == 1) {
			arr[num] = arr[num] +1;
		}
	}
		console.log(arr);
		return(arr);
}

incrementTheSeconds([1,2,3,4,5,6,7,8]);

////// Previous Lengths
// You are passed an array containing strings. Working within that same array, replace each
// string with a number – the length of the string at previous array index – and return the array.

function previousLengths(arr) {
	for (var num = 0; num < arr.length; num++) {
		if (typeof arr[num] == 'string') {
			arr[num] = arr[num].length;
			} 
		else {
		}
	}
	console.log(arr);
	return arr;
}

previousLengths(["one","two","three","four","five"]);

////// Add Seven to Most
// Build function that accepts array. Return a new array with all values except first, adding 7 to
// each. Do not alter the original array.

function addSeven(arr){
	newArr = [];

	for (var num = 1; num < arr.length; num++) {
		newArr.push(arr[num] + 7);
	}

	console.log(newArr);
	return(newArr);

}

addSeven([1,2,3,4,5]);

////// Reverse Array
// Given array, write a function to reverse values, in-place. Example: reverse([3,1,6,4,2])
// returns same array, containing [2,4,6,1,3].

function reverseArray(arr) {
	arr.reverse();
	console.log(arr);
}

reverseArray([3,1,6,4,2]);


////// Outlook: Negative
// Given an array, create and return a new one containing all the values of the provided array,
//made negative (not simply multiplied by -1). Given [1,-3,5], return [-1,-3,-5].

function outlookNegative(arr) {
	var newArr = [];
	num = 0;

	for (var num = 0; num < arr.length; num++) {
		if (arr[num] > 0) {
			newArr.push(arr[num] * -1);
		} 
		else {
			newArr.push(arr[num]);
		}
	}

	console.log(newArr);
	return newArr;
}

outlookNegative([1,-3,5]);

////// Always Hungry
// Create a function that accepts an array, and prints "yummy" each time one of the values is
// equal to "food". If no array elements are "food", then print "I'm hungry" once.

function alwaysHungry(arr) {
	var counter = 0;

	for (var num = 0; num < arr.length; num++) {
		if (arr[num] == "food") {
			counter++;
			console.log("yummy");
		}
	}

	if (arr[num] == arr[arr.length] && counter == 0) {
			console.log("I'm hungry");
	}
}

alwaysHungry([1,2,3,"food","food"]);

////// Swap Toward the Center
// Given array, swap first and last, third and third-tolast, etc. Input[true,42,"Ada",2,"pizza"]
// becomes ["pizza",42,"Ada",2,true]. Change [1,2,3,4,5,6] to [6,2,4,3,5,1].

function oddSwap(arr) {
	temp = null;

	for(var num = 0; num < Math.floor(arr.length/2); num++) {
		if (num % 2 == 0) {
			temp = arr[num];
			arr[num] = arr[(arr.length) - 1 - num];
			arr[(arr.length) - 1 - num] = temp;
		}
	}
	console.log(arr);
	return arr;
}

oddSwap([1,2,3,4,5,6]);

////// Scale the Array
// Given array arr and number num, multiply each arr value by num, and return the changed arr.

function scaleArray(arr,num){

	for (var i = 0; i < arr.length; i++) {
		arr[i] = arr[i] * num;
	}
	console.log(arr)
}

scaleArray([1,2,3,4,5],2);

