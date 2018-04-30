#Part 1

def studentsOnly ():

    students = [
        {'first_name':  'Michael', 'last_name' : 'Jordan'},
        {'first_name' : 'John', 'last_name' : 'Rosales'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]

    for i in students:
        print i['first_name'], i['last_name']

studentsOnly()

#Part 2

def studentsAndInstructors ():

    users = {
        'Students': [
            {'first_name':  'Michael', 'last_name' : 'Jordan'},
            {'first_name' : 'John', 'last_name' : 'Rosales'},
            {'first_name' : 'Mark', 'last_name' : 'Guillen'},
            {'first_name' : 'KB', 'last_name' : 'Tonel'}
        ],
        'Instructors': [
            {'first_name' : 'Michael', 'last_name' : 'Choi'},
            {'first_name' : 'Martin', 'last_name' : 'Puryear'}
        ]
    }

    studentcount = 1
    teachercount = 1

    print "Students:"
    for i in users['Students']:
        lettercount = len(i['first_name']) + len(i['last_name'])
        print studentcount, "-", i['first_name'], i['last_name'], "-", lettercount
        studentcount += 1

    print "Instructors:"
    for x in users['Instructors']:
        lettercount = len(x['first_name']) + len(x['last_name'])
        print teachercount, "-", x['first_name'], x['last_name'], "-", lettercount
        teachercount += 1
    
studentsAndInstructors()
