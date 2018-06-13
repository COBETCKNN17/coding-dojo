// Part 1

var myString: string;

myString = "Bee stinger";

myString = "9"; // Changed 9 to a string by adding quotes

// Part 2

function sayHello(name: string){
    return `Hello, ${name}!`;
 }

 console.log(sayHello("Kermit"));

 console.log(sayHello("9")); // Changed 9 to a string by adding quotes

 // Part 3

 function fullName(firstName: string, lastName: string, middleName: string){
    let fullName = `${firstName} ${middleName} ${lastName}`;
    return fullName;
 }
 
 console.log(fullName("Mary", "Moore", "Tyler"));

 console.log(fullName("Jimbo", "Jones", "")); // Added a blank middle name with an empty string

 // Part 4

 interface Student {
    firstName: string;
    lastName: string;
    belts: number;
 }
 function graduate(ninja: Student){
    return `Congratulations, ${ninja.firstName} ${ninja.lastName}, you earned ${ninja.belts} belts!`;
 }
 const christine = {
    firstName: "Christine",
    lastName: "Yang",
    belts: 2
 }
 const jay = {
    firstName: "Jay",
    lastName: "Patel",
    belts: 4 // Added an "s" to belt to fix
 }

 console.log(graduate(christine));

 console.log(graduate(jay));

 // Part 5

 class Ninja {
    fullName: string;
    constructor(
       public firstName: string,
       public lastName: string){
          this.fullName = `${firstName} ${lastName}`;
       }
    debug(){
       console.log("Console.log() is my friend.")
    }
 }

 const shane = new Ninja("Shane", "Lastname"); // Added "new" and gave Shane a first and last name as the 2 arguments.

 const turing = {
    fullName: "Alan Turing",
    firstName: "Alan",
    lastName: "Turing"
 }
 
 function study(programmer: Ninja){
    return `Ready to whiteboard an algorithm, ${programmer.fullName}?`
 }

 console.log(study(shane)); //turing cannot study as it is not an instance of Ninja. I replaced turing with shane.

 // Part 6

 var increment = x => x + 1;

console.log(increment(3));
var square = x => x * x; // removed unneeded curly braces

console.log(square(4));

var multiply = (x, y) => x * y; //adding parenthesis around x,y fixed

var math = (x, y) => {
    let sum = x + y;
    let product = x * y;
    let difference = Math.abs(x - y);
    return [sum, product, difference];
} // added needed curly braces

// Part 7

class Elephant{
    constructor(public age: number){}
    birthday = x => this.age++; // Changed to an arrow function
}
const babar = new Elephant(8);
setTimeout(babar.birthday, 1000)
setTimeout(function(){
    console.log(`Babar's age is ${babar.age}.`)
}, 2000);