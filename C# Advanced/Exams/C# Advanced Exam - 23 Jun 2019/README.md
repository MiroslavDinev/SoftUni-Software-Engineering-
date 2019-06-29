Spaceship Crafting
==================

![C:\\Users\\Acer-A715-71G\\AppData\\Local\\Microsoft\\Windows\\INetCache\\Content.Word\\startup.png](media/031a55c2c632c93e803f2bbc284b59ef.png)

*Stephen wants to build a spaceship and start travelling through the galaxy. He
has some materials, which upon mixing can give him the more advanced materials
he needs to build the spaceship. You have to help him get the job done.*

First, you will be given **a sequence of integers, representing chemical
liquids**. Afterwards, you will be given another **sequence of integers
representing physical items**.

You need to start from the **first liquid** and try to mix it with the **last
physical item**. If the **sum** of their values is **equal** to **any of the
items in the table below** – **create the item corresponding** to the **value**
and **remove both** the **liquid** and the **physical item**. Otherwise,
**remove only the liquid** and **increase** the **value** of the item **by 3**.
You need to **stop** combining when you have **no more liquids** or **physical
items**.

| **Advanced Material** | **Value needed** |
|-----------------------|------------------|
| Glass                 | 25               |
| Aluminium             | 50               |
| Lithium               | 75               |
| Carbon fiber          | 100              |

In order to build a spaceship, Stephen needs **one of each** of the **Advanced
materials**.

### Input

-   On the **first line**, you will receive the integers representing the
    **chemical liquids**, **separated** by a **single space**.

-   On the **second line**, you will receive the integers representing the
    **physical items**, **separated** by a **single space**.

### Output

-   On the **first** line of output – print if Stephen succeeded in building the
    spaceship:

    -   "**Wohoo! You succeeded in building the spaceship!**"

    -   "**Ugh, what a pity! You didn't have enough materials to build the
        spaceship.**"

-   On the **second** line - print all liquids you have left:

    -   If there are no liquids: "**Liquids left: none**"

    -   If there are liquids: "**Liquids left: {liquid1}, {liquid2}, {liquid3},
        (…)**"

-   On the **third** line - print all physical materials you have left:

    -   If there are no items: "**Physical items left: none**"

    -   If there are items: "**Physical items left: {item1}, {item2}, {item3},
        (…)"**

-   Then**,** you need to print **all** Advanced Materials and the **amount you
    have of them**, ordered **alphabetically**:

    -   **"Aluminium: {amount}"**

    -   **"Carbon fiber: {amount}"**

    -   **"Glass: {amount}"**

    -   **"Lithium: {amount}"**

### Constraints

-   All of the given numbers will be valid integers in the range **[0, 100]**.

-   Advanced materials **can be** crafted more than once.

### Examples

| **Input**                         | **Output**                                                                                                                                                                         | **Comment**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|-----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **1 25 50 50 50 25 25 24**        | **Wohoo! You succeeded in building the spaceship! Liquids left: none Physical items left: none Aluminium: 1 Carbon fiber: 1 Glass: 1 Lithium: 1**                                  | The first pair is the **first liquid** with value of 1 and the **last physical item** of value 24, their **sum** is 25, so we **craft** Glass. Then we have **sum** of 50, we **craft** Aluminium. After that we have **sum** of 75, we **craft** Lithium. Next we have **sum** of 100, so we **craft** Carbon fiber. We have **no left liquids and/or physical items**, so we **stop** trying to craft Advanced Materials, but we **have enough** of them to **build** the spaceship.                                                                                                                                       |
| **10 20 30 40 50 50 40 30 30 15** | **Ugh, what a pity! You didn't have enough materials to build the spaceship. Liquids left: none Physical items left: 39, 40, 50 Aluminium: 1 Carbon fiber: 0 Glass: 1 Lithium: 0** | **First, we take the first given liquid and the last physical item, their sum is 25 and we craft Glass, removing both of them from the collections.**                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
|                                   |                                                                                                                                                                                    | **Then, we take the next pair and their sum is 50, crafting Aluminium and again – removing both the liquid and the item.**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
|                                   |                                                                                                                                                                                    | **Next, we take the next pair and their sum is 60, so we remove the liquid and increase the item’s value by 3.**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|                                   |                                                                                                                                                                                    | **The next 2 pairs follow the same scenario, so we end up with not enough materials for building a spaceship, no liquids left and some physical items, one of which is 39 (originally 30, increased its value three times).**                                                                                                                                                                                                                                                                                                                                                                                                |

Space Station Recruitment
=========================

[./media/image2.png](./media/image2.png)
========================================

*Now that Stephen successfully established his own Space Station, he has to
recruit some astronauts to work there. You are going to help him by building a
system for that.*

Preparation
-----------

Download the skeleton provided in Judge. **Do not** change the **StartUp** class
or its **namespace**.

Problem description
-------------------

Your task is to create a repository, which stores departments by creating the
classes described below.

First, write a C\# class **Astronaut** with the following properties:

-   **Name: string**

-   **Age: int**

-   **Country: string**

The class **constructor** should receive **name, age** and **country** and
override the **ToString()** method in the following format:

**"Astronaut: {name}, {age} ({country})"**

**Next**, write a C\# class **SpaceStation** that has **data** (a collection,
which stores the entity **Astronaut**). All entities inside the repository have
the **same properties**. Also, the SpaceStation class should have those
properties:

-   **Name: string**

-   **Capacity: int**

The class **constructor** should receive **name** and **capacity**, also it
should initialize the **data** with a new instance of the collection**.**
Implement the following features:

-   Field **data** – **collection** that holds added astronauts

-   Method **Add(Astronaut astronaut)** – **adds** an **entity** to the data
    **if there is room** for him/her.

-   Method **Remove(string name)** – removes an astronaut by **given name,** if
    such **exists**, and **returns bool**.

-   Method **GetOldestAstronaut()** – returns the **oldest** astronaut.

-   Method **GetAstronaut(string name)** – returns the astronaut with the
    **given name**.

-   Getter **Count** – **returns** the **number** of astronauts.

-   **Report()** – **returns** a **string** in the following **format**:

    -   **"Astronauts working at Space Station {spaceStationName}:**  
        **{Astronaut1}**  
        **{Astronaut2}**  
        **(…)**"

Constraints
-----------

-   The **names** of the astronauts will be **always unique**.

-   The **age** of the astronauts will always be with **positive values**.

-   You will always have an astronaut added before receiving methods
    manipulating the Space Station’s astronauts.

Examples
--------

This is an example how the **SpaceStation** class is **intended to be used**.

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| //Initialize the repository SpaceStation spaceStation = new SpaceStation("Apolo", 10); //Initialize entity Astronaut astronaut = new Astronaut("Stephen", 40, "Bulgaria"); //Print Astronaut Console.WriteLine(astronaut); //Astronaut: Stephen, 40 (Bulgaria) //Add Astronaut spaceStation.Add(astronaut); //Remove Astronaut spaceStation.Remove("Astronaut name"); //false Astronaut secondAstronaut = new Astronaut("Mark", 34, "UK"); //Add Astronaut spaceStation.Add(secondAstronaut); Astronaut oldestAstronaut = spaceStation.GetOldestAstronaut(); // Astronaut with name Stephen Astronaut astronautStephen = spaceStation.GetAstronaut("Stephen"); // Astronaut with name Stephen Console.WriteLine(oldestAstronaut); //Astronaut: Stephen, 40 (Bulgaria) Console.WriteLine(astronautStephen); //Astronaut: Stephen, 40 (Bulgaria) Console.WriteLine(spaceStation.Count); //2 Console.WriteLine(spaceStation.Report()); //Astronauts working at Space Station Apolo: //Astronaut: Stephen, 40 (Bulgaria) //Astronaut: Mark, 34 (UK) |

Submission
----------

Zip all the files in the project folder except **bin** and **obj** folders

Space Station Establishment
===========================

![C:\\Users\\Acer-A715-71G\\AppData\\Local\\Microsoft\\Windows\\INetCache\\Content.Word\\project.png](media/dac08c46c06f62bbe1332839ab6d36d5.png)

*Stephen successfully started his journey in the galaxy and now he has to
collect some star power in order to establish his very own Space Station.*

You will be given an integer **n** for the **size** of the galaxy with
**square** shape. On the next **n** lines, you will receive the **rows** of the
galaxy. Stephen’s spaceship will be placed on a **random position**, marked with
the letter '**S**'. On random positions there will be stars, marked with a
**single digit**. There **may** also be **black holes**. Their **count** will be
either **0** or **2** and they are **marked** with the **letter** - '**O**'.
**All of the empty positions** will be marked with **'-'**.

Each turn, you will be given **commands** for the **player’s movement**. Move
commands will be: "**up**", "**down**", "**left**", "**right**". If he **moves**
to a **star**, he **collects energy equal** to the **digit there** and the star
**disappears**. If he moves to a **black hole**, he **appears** on the
**position** of the **other black hole** and then **both** black holes
**disappear**. If a player **goes out** of the galaxy, he goes into the void,
**disappears** from the galaxy and is lost forever. He needs **at least 50 star
power** to build the Space Station.

When **the player** is **lost** in the void **or collects enough star power,**
the journey **ends**.

### Input

-   On the first line, you are given the integer **n** – the size of the
    **square** matrix.

-   The **next n lines** holds the values for every **row**.

-   On each of the next lines you will get a move command.

### Output

-   On the first line:

    -   If the player goes to the void, print: "**Bad news, the spaceship went
        to the void.**"

    -   If the player collects enough star power, print: "**Good news! Stephen
        succeeded in collecting enough star power!**"

-   On the second line print all star power collected: "**Star power collected:
    {starPower}**"

-   In the end print the matrix.

### Constraints

-   The size of the **square** matrix will be between **[2…10].**

-   There will **always** be **0** or **2** black holes, marked with the
    **letter** - '**O**'.

-   The player position will be marked with '**S**'.

-   The player will **always** go to the void or collect enough star power.

### Examples

| **Input**                                                                               | **Output**                                                                                                                       | **Comments**                                                                                                                                                                                                                                                                                                        |
|-----------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 5 SO--- ----- ----- ----- ----O right right                                             | Bad news, the spaceship went to the void. Star power collected: 0 ----- ----- ----- ----- -----                                  | The first command is right. The player moves to **one of the black holes** and then **appears** on the other side of it (4,4). The galaxy looks like this after the first command: ----- ----- ----- ----- ----S The second command is right. The player goes **out** of the galaxy and straight into the **void**. |
| 6 S98--- 99---- 555555 ------ --77-- -6-6-6 right right down left left down right right | Good news! Stephen succeeded in collecting enough star power! Star power collected: 50 ------ ------ --S555 ------ --77-- -6-6-6 | Here we have **no** black holes and galaxy rich of stars. Our spaceship pilot manages to collect **enough** star power **without going out** of the galaxy and builds his Space Station! The stars he has collected disappeared and we can see where he was when he collected his last neeeded star power (2,2).    |
