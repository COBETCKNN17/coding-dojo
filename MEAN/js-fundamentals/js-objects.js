function jsObjects() {
    let students = [
        { name: 'Remy', cohort: 'Jan' },
        { name: 'Genevieve', cohort: 'March' },
        { name: 'Chuck', cohort: 'Jan' },
        { name: 'Osmund', cohort: 'June' },
        { name: 'Nikki', cohort: 'June' },
        { name: 'Boris', cohort: 'June' }
    ];

    for (var i = 0; i < students.length; i++) {
        console.log("Name: ", students[i].name, ", Cohort: ", students[i].cohort);

    }
}

jsObjects()

function jsObjects2() {
    let users = {
        employees: [
            { 'first_name': 'Miguel', 'last_name': 'Jones' },
            { 'first_name': 'Ernie', 'last_name': 'Bertson' },
            { 'first_name': 'Nora', 'last_name': 'Lu' },
            { 'first_name': 'Sally', 'last_name': 'Barkyoumb' }
        ],
        managers: [
            { 'first_name': 'Lillian', 'last_name': 'Chambers' },
            { 'first_name': 'Gordon', 'last_name': 'Poe' }
        ]
    };

    var employeesCount = 1;
    var managersCount = 1;

    console.log("Employees:");

    for (var x = 0; x < users.employees.length; x++) {
        console.log(employeesCount, "-", users.employees[x].first_name, users.employees[x].last_name, "-", users.employees[x].first_name.length + users.employees[x].last_name.length);
        employeesCount++;
    }

    console.log("Managers:");

    for (var y = 0; y < users.managers.length; y++) {
        console.log(managersCount, "-", users.managers[y].first_name, users.managers[y].last_name, "-", users.managers[y].first_name.length + users.managers[y].last_name.length);
        managersCount++;
    }

}

jsObjects2()