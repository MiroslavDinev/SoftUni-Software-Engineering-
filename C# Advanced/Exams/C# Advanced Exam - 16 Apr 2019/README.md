Trojan Invasion
===============

*Trojan army marches upon Sparta. Vicious waves of Trojan warriors are getting
ready to attack the Spartan defense and make their way into the city.*

**First**, you will be given a **number** equal to the **waves of Trojan
warriors**. On the **second** line you will be given the **plates of the Spartan
defense**. Then, on each next line (**for each wave**), you receive the power of
**each Trojan warrior**. Additionally, on every **third wave**, the Spartans
build a **new plate** (**extra** line with a single integer) **before** the
Trojan warriors attack. In order to enter the city, the Trojans have to
**destroy all the plates**.

**Until** there are **no more plates** or **warriors**, the **last Trojan
warrior** attacks **the first plate**:

-   If the **warrior’s** value is **greater**, he **destroys** the plate and
    **lowers** his value by the plate’s value, then attacks the **next** plate,
    **until** his value reaches 0.

-   If the **plate’s** value is **greater**, the warrior **dies** and the plate
    **decreases** its value by the warrior’s value.

-   If their values are **equal**, the warrior **dies** and the plate is
    **destroyed**.

### Input

-   **First** line: integer- the number of **waves**

-   **Second** line: integers, representing the **plates**, **separated by a
    single space**.

-   For each **wave:** integers, representing the **warriors**, **separated by a
    single space**.

    -   On every **third** wave, you will be given an **extra line** with a
        **single** integer, which will be the **plate you need to add**. **[!]**
        Add the plate **before** processing the attacks. **[!]**

### Output

-   On the first line of output – print if the Trojans destroyed the Spartan
    defense:

    -   True: “**The Trojans successfully destroyed the Spartan defense.**”

    -   False: “**The Spartans successfully repulsed the Trojan attack.**”

-   On the second line - print all plates or warriors left, separated by comma
    and a white space:

    -   If there are warriors: “**Warriors left: {warrior1}, {warrior2},
        {warrior3}, (…)**”

    -   If there are plates: “**Plates left: {plate1}, {plate2}, {plate3},
        (…)**”

### Constraints

-   All of the given numbers will be valid integers in the range [1, 100].

-   **Not all waves** may be needed to destroy the defense.

-   There will **always** be a **winning side**, meaning either no warriors or
    plates left.

### Examples

| **Input**                                     | **Output**                                                                      | **Comment**         |
|-----------------------------------------------|---------------------------------------------------------------------------------|---------------------|
| **3 10 20 30 4 5 1 10 5 5 10 10 10 4**        | **The Spartans successfully repulsed the Trojan attack. Plates left: 4**        | First wave (4 5 1): |
| **5 10 30 10 3 3 4 10 10 10 5 5 5 7 6 8 6 7** | **The Trojans successfully destroyed the Spartan defense. Warriors left: 1, 7** | First wave (3 3 4): |

-   Warrior (1) attacks Plate (10) =\> dies and plate is now 9.

-   Warrior (5) attacks Plate (9) =\> dies and plate is now 4.

-   Warrior (4) attacks Plater (4) =\> dies and plate is gone.

-   Second wave (10 5 5):

-   Warrior (5) attacks Plate (20) =\> dies and plate is now 15.

-   Warrior (5) attacks Plate (15) =\> dies and plate is now 10.

-   Warrior (10) attacks Plate (10) =\> dies and plate is gone.

-   Third wave (10 10 10):

-   Spartans build a new plate (4), plates are now: 30 4

-   Warrior (10) attacks Plate (30) =\> dies and plate is now 20.

-   Warrior (10) attacks Plate (20) =\> dies and plate is now 10.

-   Warrior (10) attacks Plate (10) =\> dies and plate is gone.

-   We have no more waves and one plate left (4) =\> see the output.

-   Warrior (4) attacks Plate (10) =\> dies and plate is now 6.

-   Warrior (3) attacks Plate (6) =\> dies and plate is now 3.

-   Warrior (3) attacks Plater (3) =\> dies and plate is gone.

-   Second wave (10 10 10):

-   Warrior (10) attacks Plate (30) =\> dies and plate is now 20.

-   Warrior (10) attacks Plate (20) =\> dies and plate is now 10.

-   Warrior (10) attacks Plate (10) =\> dies and plate is gone.

-   Third wave (5 5):

-   Spartans build a new plate (5), plates are now: 10 5

-   Warrior (5) attacks Plate (10) =\> dies and plate is now 5.

-   Warrior (5) attacks Plate (5) =\> dies and plate is gone.

-   Fourth wave (7 6):

-   Warrior (6) attacks Plate (5) =\> the warrior is now 1 and the plate is
    gone.

-   We have no more plates, so the waves stop coming =\> see the output. Also,
    we stop the input. (8 6 7 is not proceeded, but is in the input because the
    waves are 5)

Helen's Abduction
=================

*Paris has entered Sparta and he has to fight in order to abduct the wife of
Menelaus, Helen.*

After Paris got into Sparta, he has to fight his way to Helen’s chamber. In
order to do that, he has to walk through the city where dangerous enemies are
watching out for threats, but he also has to be careful not to get exhausted and
not be able to proceed with his mission. If Paris successfully reaches to her
chamber, they safely escape from the Spartans.

A standard field of Sparta looks like this:

| **Field of Sparta**                                 | **Legend**                                                                   |
|-----------------------------------------------------|------------------------------------------------------------------------------|
| \------H---                                         | **P Paris**, the player character **S Spartan, enemy H Helen - Empty space** |
| -------S--                                          |                                                                              |
| --S-------                                          |                                                                              |
| ----------                                          |                                                                              |
| -----P----                                          |                                                                              |

Each turn proceeds as follows:

-   **First**, Spartan **spawns** on the given indices.

-   **Then, Paris** moves in a direction, which **decreases** his energy by 1.

    -   It can be “**up**”, “**down**”, “**left**”, “**right**”

    -   If Paris tries to move **outside** of the field, he **doesn’t** move but
        **still** has his energy **decreased**.

-   If an enemy is on the **same cell** where Paris moves, Paris fights him,
    which **decreases** his energy by 2. If Paris’ energy **drops** at 0 or
    below, he **dies** and you should mark his position with ‘**X**’.

-   If Paris **kills** the enemy successfully, the enemy **disappears**.

-   If Paris reaches the **index** where **Helen** is, **they both run away**
    (disappear from the field)**, even if his energy is 0 or below.**

Input
-----

-   On the **first line** of input, you will receive **e** – **the energy**
    Paris has.

-   On the **second line** of input, you will receive **n** – the **number of
    rows** the field of Sparta will consist of.  
    Range: **[5-20]**

-   On the next **n lines**, you will receive how each row looks.

-   Then, **until** Paris dies, or reaches Helen, you will receive a **move
    command** and **spawn row and column**.

Output
------

-   If Paris is **runs out of energy**, print “**Paris died at {row};{col}.**”

-   If Helen is **abducted**, print “**Paris has successfully abducted Helen!
    Energy left: {energy}**”

-   Then, in all cases, **print** the **final state of the field** on the
    **console**.

Constraints
-----------

-   The field will always be **rectangular**.

-   Paris will **always** run out of energy or **reach Helen**.

-   There will be **no case** with spawn on **invalid** indices.

-   There will be **no case** with **two enemies on the same cell**.

-   There will be **no case** with enemy **spawning** on the indices **where
    Paris is**.

-   There will be **no case** with enemy **spawning** on the indices **where
    Helen is**.

Examples
--------

| **Input**                                                       | **Output**                                                                           | **Comments**                                                                                                                                                                                                                                                                                                                                                                                                    |
|-----------------------------------------------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 100 5 --H-- ----- ----- ----- --P-- up 3 0 up 3 1 up 3 2 up 3 3 | Paris has successfully abducted Helen! Energy left: 96 ----- ----- ----- SSSS- ----- | Turn 1: An enemy spawns at [3;0], Paris moves to [3;2], his energy decreases by 1. Turn 2: An enemy spawns at [3;1], Paris moves to [2;2], his energy decreases by 1. Turn 3: An enemy spawns at [3;2], Paris moves to [1;2], his energy decreases by 1. Turn 4: An enemy spawns at [3;3], Paris moves to [0;2], his energy decreases by 1, but he also moves to the index where Helen is – they both run away. |
| 3 5 --H-- ----- ----- ----- --P-- up 3 2                        | Paris died at 3;2. --H-- ----- ----- --X-- -----                                     | Turn 1: An enemy spawns at [3;2], Paris moves to [3;2], his energy decreases by 1 and fights the enemy at that index. Paris’ energy is decreased by 2, dropping it to 0 or below =\> Paris dies.                                                                                                                                                                                                                |
| 3 5 --H-- ----- ----- ----- --P-- left 1 0 down 2 0 up 3 0      | Paris died at 3;1. --H-- S---- S---- SX--- -----                                     | Turn 1: An enemy spawns at [1;0], Paris moves to [4;1], his energy decreases by 1. Turn 2: An enemy spawns at [2;0], Paris tries to move down, but [5;1] is an invalid index, so he stays at [4;1]. His energy still decreases. Turn 3: An enemy spawns at [3;0], Paris moves to [3;1], his energy drops to 0 and he cannot continue his mission.                                                               |

Fighting Arena
==============

Preparation
-----------

Download the skeleton provided in Judge. **Do not** change the **StartUp** class
or its **namespace**.

Problem description
-------------------

Your task is to create an arena which stores gladiators by creating the classes
described below.

First, write a C\# class **Weapon** with the following properties:

-   **Size: int**

-   **Solidity: int**

-   **Sharpness: int**

The class **constructor** should receive **size, solidity and sharpness**.

Next, write a C\# class **Stat** with the following properties:

-   **Strength: int**

-   **Flexibility: int**

-   **Agility: int**

-   **Skills: int**

-   **Intelligence: int**

The class **constructor** should receive **strength, flexibility, agility,
skills and intelligence.**

Next, write a C\# class **Gladiator** with the following properties and methods:

-   **Name: string**

-   **Stat: Stat**

-   **Weapon: Weapon**

-   **GetTotalPower(): int –** return the sum of the stat properties plus the
    sum of the weapon properties.

-   **GetWeaponPower(): int -** return the sum of the weapon properties.

-   **GetStatPower(): int -** return the sum of the stat properties.

The class **constructor** should receive **name, stat and weapon** and
**override ToString()** in the following format:

"[Gladiator name] - [Gladiator total power]"

" Weapon Power: [Gladiator weapon power]"

" Stat Power: [Gladiator stat power]"

Write a C\# class **Arena** that has **gladiators** (a collection which stores
the class **Gladiator**).

| **public class** Arena {                                 |
| *// TODO: implement this class*                          |
| }                                                        |
|----------------------------------------------------------|


The class **constructor** should initialize the **gladiators** with a new
instance of the collection**.** Implement the following features:

-   Field **gladiators** – **collection** that holds added gladiators

-   **Property Name - string**

-   Method **Add(Gladiator gladiator)** – adds an gladiator to the arena.

-   Method **Remove(string name)** – removes an gladiator by given name.

-   Method **GetGladitorWithHighestStatPower()** – returns the Gladiator which
    has the highest stat.

-   Method **GetGladitorWithHighestWeaponPower()** – returns the Gladiator which
    poses the weapon with the highest power.

-   Method **GetGladitorWithHighestTotalPower()** – returns the Gladiator which
    has the highest total power.

-   Getter **Count** – returns the number of stored heroes.

-   Оverride **ToString()** – by the format below.

    "[Arena name] - [count of gladiators] gladiators are participating."

Constraints
-----------

-   The names of the gladiators will be always unique.

-   The weapons and the stat properties of the gladiators will always be with
    positive values.

-   The weapon power, stat power and total power of the gladiators will always
    be different.

-   You will always have a gladiator with the highest stat, weapon and total
    power.

Examples
--------

This is an example how the **Arena** class is **intended to be used**.

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| //Creates arena Arena arena = new Arena("Armeec"); //Creates stats Stat firstGlariatorStat = new Stat(20, 25, 35, 14, 48); Stat secondGlariatorStat = new Stat(40, 40, 40, 40, 40); Stat thirdGlariatorStat = new Stat(20, 25, 35, 14, 48); //Creates weapons Weapon firstGlariatorWeapon = new Weapon(5, 28, 100); Weapon secondGlariatorWeapon = new Weapon(5, 28, 100); Weapon thirdGlariatorWeapon = new Weapon(50, 50, 50); //Creates gladiators Gladiator firstGladiator = new Gladiator("Stoyan", firstGlariatorStat, firstGlariatorWeapon); Gladiator secondGladiator = new Gladiator("Pesho", secondGlariatorStat, secondGlariatorWeapon); Gladiator thirdGladiator = new Gladiator("Gosho", thirdGlariatorStat, thirdGlariatorWeapon); //Adds gladiators to arena arena.Add(firstGladiator); arena.Add(secondGladiator); arena.Add(thirdGladiator); //Prints gladiators count at the arena Console.WriteLine(arena.Count); //Gets strongest gladiator and print him Gladiator strongestGladiator = arena.GetGladitorWithHighestTotalPower(); Console.WriteLine(strongestGladiator); //Gets gladiator with the strongest weapon and print him Gladiator bestWeaponGladiator = arena.GetGladitorWithHighestWeaponPower(); Console.WriteLine(bestWeaponGladiator); //Gets gladiator with the strongest stat and print him Gladiator bestStatGladiator = arena.GetGladitorWithHighestStatPower(); Console.WriteLine(bestStatGladiator); //Removes gladiator arena.Remove("Gosho"); //Prints gladiators count at the arena Console.WriteLine(arena.Count); //Prints the arena Console.WriteLine(arena); |

Submission
----------

Zip all the files in the project folder except **bin** and **obj** folders
