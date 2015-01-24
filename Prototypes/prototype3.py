__author__ = 'Dylan J. Hellems'

import random, sys, math

robots = {1: 500, 2: 0, 3: 0}
actions = 2
max_actions = 4
oil = 50
metal = 0
components = 0
expansion = 0
fortification = 0
expand_chance = 0.5
improved_expand = False
improved_collect = False
improved_upkeep = False


def choose(val, val2, req):
    print("Whick robots would you like to use? (1, 2 , 3)")
    choice = int(input("\n"))
    choice2 = int(input("How many would you like to spend? min: " + str(val) + " max: " + str(val2) + "\n\n"))
    if choice2 < val or choice2 > val2:
        print("You can't use that amount!")
        choose(val, val2, req)
    rand = ((math.floor(random.random() * 100)) % choice2 + 1)
    if choice == 1:
        if robots[1] - choice2 > -1:
            robots[1] -= rand
            print("You lost " + str(rand) + " MK1 robots!")
        else:
            print("You don't have the resources!")
            choose(val, val2, req)
    elif choice == 2:
        if req < 2:
            print("You can't use MK2s for this task")
            choose(val, val2, req)
        elif robots[2] - choice2 > -1:
            robots[2] -= rand
            print("You lost " + str(rand) + " MK2 robots!")
        else:
            print("You don't have the resources!")
            choose(val, val2, req)
    elif choice == 3:
        if req < 3:
            print("You can't use MK3s for this task")
            choose(val, val2, req)
        if robots[3] - choice2 > -1:
            robots[3] -= rand
            print("You lost " + str(rand) + " MK3 robots!")
        else:
            print("You don't have the resources!")
            choose(val, val2, req)
    else:
        print("\nWhy you do dis?\n")
        choose(val, val2, req)

    print(str(choice2))
    return choice2


def rand_event():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    rand = random.random()

    if rand < (0.2 + (0.05 * (expansion - fortification))):
        rand = math.floor(((random.random() * 100) % 3) + 1)
        oil_now = max(oil - 5, 0)
        oil_lost = oil - oil_now
        robots_now = max(robots[rand] - 100, 0)
        robots_lost = robots[rand] - robots_now
        oil = oil_now
        robots[rand] = robots_now
        print("\n------------------------------------")
        print("Oh noes! A stuff happened!")
        print("You lost " + str(robots_lost) + " MK" + str(rand) + " robots and " + str(oil_lost) + " oil!")
        print("------------------------------------\n")


def end_turn():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    if actions > 1:
        actions -= 1
        printerface()

    rand_event()
    if not improved_upkeep:
        oil -= 10
        print("You lost 10 oil to upkeep!")
    if robots[1] < 1 and robots[2] < 1 and robots[3] < 1 or oil < 1:
        print("You lose!")
        sys.exit(0)
    elif expansion > 9:
        print("You win!")
        sys.exit(0)
    else:
        actions = 2
        printerface()


def expand():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    rand = random.random()
    choice = choose(50, 300, 1)
    if rand < (expand_chance + ((choice - 50) / 100)):
        expansion += 1
        print("You expanded!")
    else:
        print("You failed in expanding!")

    end_turn()


def collect():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    print("------------------------------------")
    print("Choose an action: ")
    print("1. Collect oil")
    print("2. Collect metal")
    print("3. Collect components")
    print("4. Back")

    choice = int(input("\n"))
    if choice == 1:
        choice = choose(50, 250, 3)
        if improved_collect:
            to_add = 40 + math.floor((choice - 50) / 5)
            oil += to_add
            print("Gained " + str(to_add) + " oil!")
        else:
            to_add = 20 + math.floor((choice - 50) / 10)
            oil += to_add
            print("Gained " + str(to_add) + " oil!")
    elif choice == 2:
        choice = choose(50, 250, 3)
        if improved_collect:
            to_add = 20 + math.floor((choice - 50) / 5)
            metal += to_add
            print("Gained " + str(to_add) + " metal!")
        else:
            to_add = 10 + math.floor((choice - 50) / 10)
            metal += to_add
            print("Gained " + str(to_add) + " metal!")
    elif choice == 3:
        choice = choose(50, 250, 3)
        if improved_collect:
            to_add = 20 + math.floor((choice - 50) / 5)
            components += to_add
            print("Gained " + str(to_add) + " components!")
        else:
            to_add = 10 + math.floor((choice - 50) / 10)
            components += to_add
            print("Gained " + str(to_add) + " components!")
    elif choice == 4:
        printerface()
    else:
        print("\nWhy you do dis?\n")
        improve()

    end_turn()


def improve():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    print("------------------------------------")
    print("Choose an action: ")
    if expansion % 3 > 1:
        print("1. Improve collecting (-100 MK1 robots; -30 components)")
    if expansion % 3 > 2:
        print("2. Improve expanding (-100 MK1 robots; -20 components")
    if expansion % 3 > 3:
        print("3. Improve upkeep (-100 MK1 robots; -50 components; -25 oil")
    print("4. Back")

    choice = int(input("\n"))
    if choice == 1 and expansion % 3 > 1:
        if improved_collect:
            print("You can't improve this any further!")
            improve()
        elif robots[1] - 100 < 0 or components - 30 < 0:
            print("You don't have the resources!")
            improve()
        else:
            improved_collect = True
            robots[1] -= 100
            components -= 30
            print("Collecting improved!")
    elif choice == 2 and expansion % 3 > 2:
        if improved_expand:
            print("You can't improve this any further!")
            improve()
        elif robots[1] - 100 < 0 or components - 50 < 0:
            print("You don't have the resources!")
            improve()
        else:
            improved_expand = True
            expand_chance = 0.75
            robots[1] -= 100
            components -= 50
            print("Expanding improved!")
    elif choice == 3 and expansion % 3 > 3:
        if improved_upkeep:
            print("You can't improve this any further!")
            improve()
        elif robots[1] - 100 < 0 or components - 20 < 0 or oil - 25 < 1:
            print("You don't have the resources!")
            improve()
        else:
            improved_upkeep = True
            max_actions = 6
            robots[1] -= 100
            components -= 20
            oil -= 25
            print("Upkeep improved!")
    elif choice == 4:
        printerface()
    else:
        print("\nWhy you do dis?\n")
        improve()

    end_turn()


def fortify():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    choice = choose(50, 350, 2)
    fortification += math.floor(choice / 100)
    print("Fortifications improved!")
    end_turn()


def manufacture():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    print("Choose an action: ")
    print("1. Make 250 MK2 robots (-100 MK1 robots; -10 metal)")
    print("2. Make 250 MK3 robots (-100 MK2 robots; -20 metal)")
    print("3. Back")

    choice = int(input("\n"))
    if choice == 1:
        if robots[1] - 100 > -1 and metal - 10 > -1:
            robots[1] -= 100
            robots[2] += 250
            metal -= 10
        else:
            print("You don't have the resources!")
            manufacture()
    elif choice == 2:
        if robots[2] - 100 > -1 and metal - 20 > -1:
            robots[2] -= 100
            robots[3] += 250
            metal -= 20
        else:
            print("You don't have the resources!")
            manufacture()
    elif choice == 3:
        printerface()
    else:
        print("\nWhy you do dis?\n")
        manufacture()

    end_turn()


def power_up():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    if max_actions - 2 < 0:
        print("You can't take that many actions")
        printerface()
    if oil - 20 > -1:
        oil -= 20
        actions += 2
    else:
        print("You don't have the resources")
        printerface()

    printerface()


def printerface():
    global robots, oil, metal, components, actions, max_actions, expand_chance, improved_collect, improved_expand, improved_upkeep, expansion, fortification
    print("------------------------------------")
    print("You have " + str(robots[1]) + " MK1 robots.")
    print("You have " + str(robots[2]) + " MK2 robots.")
    print("You have " + str(robots[3]) + " MK3 robots.")
    print("You have " + str(oil) + " oil.")
    print("You have " + str(metal) + " metal.")
    print("You have " + str(components) + " components.")
    print("Your expansion level is " + str(expansion))
    print("Your fortification level is " + str(fortification) + "\n")
    print("------------------------------------")
    print("You have " + str(actions) + " actions left out of " + str(max_actions) + " possible actions!")
    print("Choose an action: ")
    print("1. Expand (" + str(expand_chance * 100) + "% to expand; lose robots; need MK1s at least)")
    print("2. Collect (lose robots to gain resources)")
    print("3. Improve (spend resources to improve actions)")
    print("4. Fortify (lose robots to gain defense; need MK2s at least)")
    print("5. Manufacture (convert robots)")
    print("6. Power up (burn 20 oil to gain 2 actions)")

    choice = int(input("\n"))
    if choice == 1:
        expand()
    elif choice == 2:
        collect()
    elif choice == 3:
        improve()
    elif choice == 4:
        fortify()
    elif choice == 5:
        manufacture()
    elif choice == 6:
        power_up()
    else:
        print("\nWhy you do dis?\n")
        printerface()


printerface()
