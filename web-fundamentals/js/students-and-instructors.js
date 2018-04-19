function studentsInstructorsBasic(){
    var students = [ 
        {first_name:  'Michael', last_name : 'Jordan'},
        {first_name : 'John', last_name : 'Rosales'},
        {first_name : 'Mark', last_name : 'Guillen'},
        {first_name : 'KB', last_name : 'Tonel'}
   ]

   for (var x = 0; x < students.length; x++){
       console.log(students[x].first_name, students[x].last_name);
   }

}

studentsInstructorsBasic();

function studentsInstructorsBonus(){
var users = {
    'Students': [ 
        {first_name:  'Michael', last_name : 'Jordan'},
        {first_name : 'John', last_name : 'Rosales'},
        {first_name : 'Mark', last_name : 'Guillen'},
        {first_name : 'KB', last_name : 'Tonel'}
     ],
    'Instructors': [
        {first_name : 'Michael', last_name : 'Choi'},
        {first_name : 'Martin', last_name : 'Puryear'}
     ]
    }
var studentCount = 1;
var instructorCount = 1;

    console.log("Students:");

    for (var x = 0; x < users.Students.length; x++){
        console.log(studentCount, "-", users.Students[x].first_name, users.Students[x].last_name, "-", users.Students[x].first_name.length+users.Students[x].last_name.length);
        studentCount++;
    }

    console.log("Instructors:");

    for (var y = 0; y < users.Instructors.length; y++){
        console.log(instructorCount, "-", users.Instructors[y].first_name, users.Instructors[y].last_name, "-", users.Instructors[y].first_name.length+users.Instructors[y].last_name.length);
        instructorCount++;
    }

}    
studentsInstructorsBonus();