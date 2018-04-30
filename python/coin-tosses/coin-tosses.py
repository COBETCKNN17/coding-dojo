def coinTosses ():
    import random
    headcount = 0
    tailcount = 0

    print "Starting the program..."
    for i in range (1,5000):
        flip = random.randint(1,2)
        if flip == 1:
            headcount += 1
            print "Attempt #", i, " Throwing a coin... It's heads! ... Got ", headcount, " head(s) and ", tailcount, " tail(s) so far."
        if flip == 2:
            tailcount += 1
            print "Attempt #", i, " Throwing a coin... It's tails! ... Got ", headcount, " head(s) and ", tailcount, " tail(s) so far."

    print "Ending the program, thank you!"

coinTosses()