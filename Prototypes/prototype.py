__author__ = 'Dylan J. Hellems'

import random, sys, math

robots = 10
oil = 50
metal = 0
expansion = 0
expand_chance = 0.5
improved_expand = False
improved_collect = False
improved_upkeep = False


def rand_event():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, expansion
    rand = random.random()

    if rand < (0.2 + (0.05 * expansion)):
        oil -= 5
        robots -=1
        print("\n------------------------------------")
        print("Oh noes! A stuff happened!")
        print("You lost a robot and 5 oil!")
        print("------------------------------------\n")


def end_turn():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion
    if improved_upkeep:
        oil -= math.ceil(robots * 0.5)
        print("Lost " + str(math.ceil(robots * 0.5)) + " oil for upkeep!")
    else:
        oil -= math.ceil(robots * 0.75)
        print("Lost " + str(math.ceil(robots * 0.75)) + " oil for upkeep!")
    rand_event()
    if robots < 1 or oil < 1:
        print("You lose!")
        sys.exit(0)
    elif expansion > 9:
        print("You win!")
        sys.exit(0)
    else:
        printerface()


def expand():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, expansion
    rand = random.random()
    if rand < expand_chance:
        if improved_expand:
            robots += 2
            print("Gained 2 robots!")
        else:
            robots += 1
            print("Gained 1 robot!")
        expansion += 1
    else:
        if improved_expand:
            robots -= 2
            print("Lost 2 robots!")
        else:
            robots -= 1
            print("Lost 1 robots!")

    end_turn()


def collect():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, expansion
    print("------------------------------------")
    print("Choose an action: ")
    print("1. Collect oil")
    print("2. Collect metal")
    print("3. Back")

    choice = int(input("\n"))
    if choice == 1:
        if improved_collect:
            oil += 20
            robots -= 1
            print("Gained 20 oil; lost 1 robot!")
        else:
            oil += 10
            robots -= 1
            print("Gained 10 oil; lost 1 robot!")
    elif choice == 2:
        if improved_collect:
            metal += 20
            robots -= 1
            print("Gained 20 metal; lost 1 robot!")
        else:
            metal += 10
            robots -= 1
            print("Gained 10 metal; lost 1 robot!")
    elif choice == 3:
        printerface()
    else:
        print("\nWhy you do dis?\n")
        improve()


    end_turn()


def improve():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion
    print("------------------------------------")
    print("Choose an action: ")
    print("1. Improve collecting (-3 robots; -30 metal)")
    print("2. Improve expanding (-6 robots; -20 metal")
    print("3. Improve upkeep (-6 robots; -25 metal")
    print("4. Back")

    choice = int(input("\n"))
    if choice == 1:
        if improved_collect:
            print("You can't improve this any further!")
            improve()
        elif robots - 3 < 0 or metal - 30 < 0:
            print("You don't have the resources!")
            improve()
        else:
            improved_collect = True
            robots -= 3
            metal -= 30
            print("Collecting improved!")
    elif choice == 2:
        if improved_expand:
            print("You can't improve this any further!")
            improve()
        elif robots - 6 < 0 or metal - 15 < 0:
            print("You don't have the resources!")
            improve()
        else:
            improved_expand = True
            expand_chance = 0.75
            robots -= 6
            metal -= 15
            print("Expanding improved!")
    elif choice == 3:
        if improved_upkeep:
            print("You can't improve this any further!")
            improve()
        elif robots - 6 < 0 or metal - 20 < 0:
            print("You don't have the resources!")
            improve()
        else:
            improved_upkeep = True
            robots -= 6
            metal -= 20
            print("Upkeep improved!")
    elif choice == 4:
        printerface()
    else:
        print("\nWhy you do dis?\n")
        improve()

    end_turn()


def printerface():
    global robots, oil, metal, expand_chance, improved_collect, improved_expand, expansion
    print("You have " + str(robots) + " robots.")
    print("You have " + str(oil) + " oil.")
    print("You have " + str(metal) + " metal.")
    print("Your expansion level is " + str(expansion))
    print("------------------------------------")
    print("Choose an action: ")
    print("1. Expand (" + str(expand_chance * 100) + "% to gain a robot; else lose a robot)")
    print("2. Collect (lose a robot to gain resources)")
    print("3. Improve (spend resources to improve actions)")

    choice = int(input("\n"))
    if choice == 1:
        expand()
    elif choice == 2:
        collect()
    elif choice == 3:
        improve()
    else:
        print("\nWhy you do dis?\n")
        printerface()


printerface()
