def scoresGrades ():
    import random

    print "Scores and Grades:"
    for i in range (1,10):
        score = random.randint(60,100)
        if score >= 90:
            print "Score:", score, "; Your grade is A"
        if score >= 80 and score < 90:
            print "Score:", score, "; Your grade is B"
        if score >= 70 and score < 80:
            print "Score:", score, "; Your grade is C"
        if score >= 60 and score < 70:
            print "Score:", score, "; Your grade is D"
        if score < 60:
            print "Score:", score, "; You failed, but that should not be possible."

    print "End of the program. Bye!"

scoresGrades()