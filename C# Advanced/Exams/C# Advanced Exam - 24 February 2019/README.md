 Club Party
===========

*A new club has opened in town and everyone wants to go partying. The club has
many halls and people may only go there with reservations.*

You will be given **n** – an integer specifying the **halls' maximum capacity**.
Then you will be given input line which will contain **English alphabet
letters** and **numbers**, separated by a **single space**. The input for the
line should be read **from the last inserted to the first one**. The **letters**
represent the **halls** and the **numbers** – the **people in a single
reservation**. Companies of people should go in the halls. The **first entered**
hall is the **first which people are entering**. Every reservation takes
**specific capacity**, equal to its number.

When a hall **overflows** (it **cannot contain** a given number of people due to
lack of enough **free capacity)**, it passes the people to the **next entered
hall**. If there is **no open hall** and you receive a reservation, you should
**skip it**.

If a hall overflows you must **remove it**, and print it on the console, along
with all of the companies of people it **currently contains**. After you’ve
removed that hall, **the next one** becomes the **first in the order** – people
will **first be passed to it**.

### Input

-   The first line will be halls' maximum capacity.

-   The second line will contain letters and digits separated by a space.

### Output

-   For output, you must print a hall, every time it overflows, after removing
    it.

-   The format is the following: **{hall} -\> {reservation1}, {reservation2}…**

-   Where **{hall}** is the letter that corresponds to that hall, and the
    **reservations** are the numbers.

### Constraints

-   The halls will only be English alphabet letters.

-   Each hall’s letter will always be unique.

-   The integer **n** will be in the range **[0, 500]**.

-   The reservations will always be valid integers in the range **[0, 500]**.

### Examples 

| Input                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | Output                                    |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------|
| 60 1 20 b 20 20 a                                                                                                                                                                                                                                                                                                                                                                                                                                                                    | a -\> 20, 20, 20                          |
| Comment                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |                                           |
| “a” is the first entered hall. Then we receive the reservations 20 and 20 which are passed to “a”. Then we get the hall “b”. Then again, we receive a reservation 20. “a” still has enough capacity to hold the people so they enter there. Then we get the reservation 1. “a” has capacity 60/60 – it overflows, so we pass the person to the next hall. We find “b” and we pass the person to “b”. “a” is then removed and printed on the console. “b” becomes the first hall now. |                                           |
| Input                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | Output                                    |
| 50 15 a 40 30 20 c 15 10 b                                                                                                                                                                                                                                                                                                                                                                                                                                                           | b -\> 10, 15, 20 c -\> 30                 |
| Input                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | Output                                    |
| 40 20 20 20 20 20 20 D F 15 5 M 26 38                                                                                                                                                                                                                                                                                                                                                                                                                                                | M -\> 5, 15, 20 F -\> 20, 20 D -\> 20, 20 |

Tron Racers
===========

*The new TRON tournament has started and you have to keep track of the players
on the field.*

You will be given an integer **n** for the size of the matrix. On the next **n**
lines, you will receive the rows of the matrix. The game starts with two players
(first player is marked with **"f"** and the second player is marked with
**"s"**) in random positions and **all of the empty slots** will be filled with
**"\*"**.

Each turn you will be given commands **respectively for each player’s
movement.** The **first command** is for the first player and the **second** is
for the second player. After a player moves, **he leaves a trail** on the field.
The symbol that marks the trail is the same as the player's symbol. If a player
**goes out** of the matrix, he comes in from **the other side**. For example, if
the player is on 0, 0 and the next command is left, he goes to the last spot in
the first row.

If a player steps on the other player's trail, he dies. When a player dies in
the field, you should write **"x"** in the position where he died.

When **only one of the players** is left alive on the field the game ends.

### Input

-   On the first line, you are given the integer N – the size of the square
    matrix.

-   The next N lines holds the values for every row.

-   On each of the next lines you will get two commands separated by space .

### Output

-   In the end print the matrix.

### Constraints

-   The size of the matrix will be between **[2…20].**

-   There will always be exactly two players.

-   The players will always be indicated with **"f"** for the first one and
    **"s"** for the second one.

-   There will always be enough commands to finish the game with one player
    alive.

-   There will not be commands where a player goes back and steps on his trail
    from the previous turn.

-   Commands will be in the format **up**, **down**, **left** or **right**.

### Examples

| Input                                                                                                                | Output                                     | Comments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|----------------------------------------------------------------------------------------------------------------------|--------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 5 \*\*\*f\* \*\*s\*\* \*\*\*\*\* \*\*\*\*\* \*\*\*\*\* down down right down down right down down down left left left | \*\*\*f\* \*\*sff \*\*s\*f \*\*ssf \*\*sxf | The first command is **down down** so **f** moves down and **s** moves down. After each turn the field is: 1 2 3 4 5 6 \*\*\*f\* \*\*\*f\* \*\*\*f\* \*\*\*f\* \*\*\*f\* \*\*\*f\* \*\*sf\* \*\*sff \*\*sff \*\*sff \*\*sff \*\*sff \*\*s\*\* \*\*s\*\* \*\*s\*f \*\*s\*f \*\*s\*f \*\*s\*f \*\*\*\*\* \*\*s\*\* \*\*ss\* \*\*ssf \*\*ssf \*\*ssf \*\*\*\*\* \*\*\*\*\* \*\*\*\*\* \*\*\*s\* \*\*ssf \*\*sxf On turn 6 **f** crashes into **s**'s trail and **f** dies. As there is only one player left alive **s** is the only one left he is the winner. |
| 4 \*f\*\* \*\*\*\* \*\*s\* \*\*\*\* down up down right right right                                                   | \*f\*\* \*fss \*fx\* \*\*\*\*              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |

Heroes
======

Preparation
-----------

Download the skeleton provided in Judge. **Do not** change the **StartUp** class
or its **namespace**.

Problem description
-------------------

Your task is to create a repository which stores hero by creating the classes
described below.

First, write a C\# class **Item** with the following properties:

-   **Strength: int**

-   **Ability: int**

-   **Intelligence: int**

The class **constructor** should receive **strength, ability and intelligence**
and override the **ToString()** method in the following format:

**"Item:"**

**" \* Strength: {Strength Value}"**

**" \* Ability: {Ability Value}"**

**" \* Intelligence: {Intelligence Value}"**

Next, write a C\# class **Hero** with the following properties:

-   **Name: string**

-   **Level: int**

-   **Item: Item**

The class **constructor** should receive **name, level and item** and override
the **ToString()** method in the following format:

**"Hero: {Name} – {Level}lvl"**

**"Item:"**

**" \* Strength: {Strength Value}"**

**" \* Ability: {Ability Value}"**

**" \* Intelligence: {Intelligence Value}"**

Write a C\# class **HeroRepository** that has data (a collection which stores
the entity **Hero**). All entities inside the repository have the same
properties.

| **public class** HeroRepository {                                 |
| *// TODO: implement this class*                                   |
| }                                                                 |
|-------------------------------------------------------------------|


The class constructor should initialize the **data** with a new instance of the
collection**.** Implement the following features:

-   Field **data** – collection that holds added heroes

-   Method **Add(Hero hero)** – adds an entity to the data.

-   Method **Remove(string name)** – removes an entity by given hero name.

-   Method **GetHeroWithHighestStrength()** – returns the Hero which poses the
    item with the highest stength.

-   Method **GetHeroWithHighestAbility()** – returns the Hero which poses the
    item with the highest ability.

-   Method **GetHeroWithHighestIntelligence()** – returns the Hero which poses
    the item with the highest intellgence.

-   Getter **Count** – returns the number of stored heroes.

-   Оverride **ToString()** – Print all the heroes.

Constraints
-----------

-   The names of the heroes will be always unique.

-   The items of the heroes will always be with positive values.

-   The items of the heroes will always be different.

-   You will always have an item with the highest strength, ability and
    intelligence.

Examples
--------

This is an example how the **HeroRepository** class is **intended to be used**.

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| //Initialize the repository HeroRepository repository = new HeroRepository(); //Initialize entity Item item = new Item(23, 35, 48); //Print Item Console.WriteLine(item); //Item: // \* Strength: 23 // \* Ability: 35 // \* Intelligence: 48 //Initialize entity Hero hero = new Hero("Hero Name", 24, item); //Print Hero Console.WriteLine(hero); //Hero: Hero Name - 24lvl //Item: // \* Strength: 23 // \* Ability: 35 // \* Intelligence: 48 //Add Hero repository.Add(hero); //Remove Hero repository.Remove("Hero Name"); Item secondItem = new Item(100, 20, 13); Hero secondHero = new Hero("Second Hero Name", 125, secondItem); //Add Heroes repository.Add(hero); repository.Add(secondHero); Hero heroStrength = repository.GetHeroWithHighestStrength(); // Hero with name Second Hero Hero heroAbility = repository.GetHeroWithHighestAbility(); // Hero with name Hero Name Hero heroIntelligence = repository.GetHeroWithHighestIntelligence(); // Hero with name Hero Console.WriteLine(repository.Count); //2 Console.WriteLine(repository); //Hero: Hero Name - 24lvl //Item: //\*Strength: 23 // \* Ability: 35 // \* Intelligence: 48 //Hero: Second Hero Name - 125lvl //Item: // \* Strength: 100 // \* Ability: 20 // \* Intelligence: 13 |

Submission
----------

Zip all the files in the project folder except **bin** and **obj** folders
