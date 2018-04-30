def draw_stars(x):
    for i in x:
        if (isinstance(i, int)):
            print "*" * i
        if (isinstance(i, basestring)):
            print i[0].lower() * len(i)
        else:
            continue

draw_stars([4, 6, 1, 3, 5, 7, 25])

draw_stars([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])