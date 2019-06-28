Problem 4 – Hospital

Your task will be to prepare an electronic register for a hospital. In the
hospital we have different departments:

-   Cardiology

-   [Oncology](https://en.wikipedia.org/wiki/Oncology)

-   [Emergency department](https://en.wikipedia.org/wiki/Emergency_department)

-   etc.

Each department has **20** rooms for patients and **each room has 3 beds**. When
a new patient goes in the hospital, he/she is placed on the first free bed in
the department. If there are no free beds, the patient should go in another
hospital. Of course, in every hospital there are doctors. Each doctor can have
patients in a different department. You will receive information about patients
in the format **{Department} {Doctor} {Patient}**

After the "Output" command you will receive some other commands with what kind
of output you need to print. The commands are:

-   **{Department}** – You need to **print all patients** in this department in
    the **order of receiving**

-   **{Department} {Room}** – You need to **print all patients** in this room in
    **alphabetical order**

-   **{Doctor}** – you need to **print all patients** for this doctor in
    **alphabetical order**

The program ends when you receive command "End".

### Input

On the first lines you will receive info for the hospital, department, doctors
and patients in the following format:

**{Department} {Doctor} {Patient}**

When you read the "**Output**" line you will get one or more commands telling
you what you need to print

Read commands for printing, ‘till you reach the command "**End**"

### Output

-   **{Department}** – print all patients in this department in order of
    receiving on new line

-   **{Department} {Room}** – print all patients in this room in alphabetical
    order each on new line

-   **{Doctor}** – print all patients that are healed from doctor in
    alphabetical order on new line

### Constraints

-   **{Department}** – single word with length **1 \< n \< 100**

-   **{Doctor}** – name and surname, both with length **1 \< n \< 20**

-   **{Patient}** – unique name with length **1 \< n \< 20**

-   **{Room}** – integer **1 \<= n \<= 20**

-   Time limit: 0.3 sec. Memory limit: 16 MB.

### Examples

| **Input**                                                                                                                                                                                                                                           | **Output**             |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------|
| Cardiology Petar Petrov Ventsi Oncology Ivaylo Kenov Valio Emergency Mariq Mircheva Simo Cardiology Genka Shikerova Simon Emergency Ivaylo Kenov NuPogodi Cardiology Gosho Goshov Esmeralda Oncology Gosho Goshov Cleopatra Output Cardiology End   | Ventsi Simon Esmeralda |
| **Input**                                                                                                                                                                                                                                           | **Output**             |
| Cardiology Petar Petrov Ventsi Oncology Ivaylo Kenov Valio Emergency Mariq Mircheva Simo Cardiology Genka Shikerova Simon Emergency Ivaylo Kenov NuPogodi Cardiology Gosho Goshov Esmeralda Oncology Gosho Goshov Cleopatra Output Cardiology 1 End | Esmeralda Simon Ventsi |
| **Input**                                                                                                                                                                                                                                           | **Output**             |
| Cardiology Petar Petrov Ventsi Oncology Ivaylo Kenov Valio Emergency Mariq Mircheva Simo Cardiology Genka Shikerova Simon Emergency Ivaylo Kenov NuPogodi Cardiology Gosho Goshov Esmeralda Oncology Gosho Goshov Cleopatra Output Ivaylo Kenov End | NuPogodi Valio         |

Problem 2 – Sneaking
====================

After our hero Sam got the recipe from the first problem, there is another thing
he needs to check off from his to-do list. In order to make the recipe even more
valuable, he needs to “eliminate” anyone who possesses the knowledge of it. That
person is Sam’s sworn enemy - **Nikoladze**. Sam needs to get through a
rectangular room of **patrolling enemies** until he finally **reaches
Nikoladze**.

A standard room looks like this:

| **Room**                                           | **Legend**                                                                                           |
|----------------------------------------------------|------------------------------------------------------------------------------------------------------|
| ......N...                                         | **S Sam**, the player character **b/d left/right-facing patrolling enemy N Nikoladze . Empty space** |
| b.........                                         |                                                                                                      |
| ..d.......                                         |                                                                                                      |
| ......d...                                         |                                                                                                      |
| .....S....                                         |                                                                                                      |

Each turn proceeds as follows:

-   **First, Enemies** move either **left** or **right**, depending on which
    **direction** they are **facing** (**b** goes **right**, **d** goes
    **left**)

    -   If an enemy is standing on the **edge** of the room, he flips his
        **direction** (from **d** to **b** or from **b** to **d**) and **doesn’t
        move** for the rest of the turn.

-   If an enemy is on the **same row** as Sam, and also **facing Sam** (eg.
    **.b.S.**), the **enemy kills Sam**.

-   After that, Sam moves in the **direction** he is instructed to (either
    **U**/**D**/**L**/**R** or **W**).

    -   **U** -\> **Up**, **D** -\> **Down**, **L** -\> **Left**, **R** -\>
        **Right**, **W** -\> **Wait (Sam doesn’t move)**

-   If **Sam** moves **onto an enemy** (**same row** and **column**), Sam
    **kills** the enemy and **leaves no trace of him**.

-   If Sam is reaches the **same row** as **Nikoladze**, **Sam** kills
    **Nikoladze** (replacing him with an **X**)

Input
-----

-   On the **first line** of input, you will receive n – the **number of rows**
    the **room** will consist of. Range: **[2-20]**

-   On the next **n lines**, you will receive the **room**, which Sam will have
    to navigate.

-   On the **final line** of input, you will receive a sequence of
    **directions** – one of (**U**, **D**, **L**, **R**, **W**)

Output
------

-   If Sam is **killed**, print “**Sam died at {row}, {col}**”

-   If Nikoladze is **killed**, print “**Nikoladze killed!**”

-   Then, in both cases, **print** the **final state of the room** on the
    **console**, with either **Sam** or **Nikoladze’s symbols** replaced by an
    **X**.

Constraints
-----------

-   The room will always be **rectangular**.

-   There will **always** be enough moves for **Sam** to reach **Nikoladze**

-   There will be **no case** where **Sam** is instructed to move **out of the
    bounds of the room**.

-   There will be **no case** with **two enemies on the same row**.

-   There will be **no case** with an **enemy and Nikoladze** standing on the
    **same row**.

-   There will be **no case** where Sam reaches the **same row and column** as
    **Nikoladze**.

Examples
--------

| **Input**                                                                                         | **Output**                                                                                            | **Comments**                                                                                                                                                                                                                                           |
|---------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 5 ......N... b......... ..d....... ......d... .....S.... UUUUR                                    | Sam died at 2, 5 ......N... ...b...... b....X.... .......... ..........                               | Turn 1: Enemies move, then Sam steps on the enemy on the 4th row. Turn 2: Enemies move, then Sam moves. Turn 3: Enemy 2 turns around, sees Sam and kills him.                                                                                          |
| 3 N...... .b..... ..dS... WUUU                                                                    | Nikoladze killed! X..S... ....... b......                                                             | Turn 1: Enemies move, Sam waits. Turn 2: Enemies move, Sam goes up, steps on an enemy. Turn 3: Enemies move, Sam goes up, kills Nikoladze.                                                                                                             |
| 6 ............. ....S........ .b........... ...........d. ............. ....N........ WWWDWWWDDRD | Nikoladze killed! ............. ............. ............b d............ ............. ....XS....... | Turn 1/2/3: Enemies move, Sam waits. Turn 4: Enemies move, Sam goes down. Turn 5/6/7: Enemies move, Sam waits. Turn 8/9: Enemies move, Sam goes down. Turn 10: Enemies move, Sam goes right. Turn 11: Enemies move, Sam goes down and kills Nikoladze. |

SoftUni Parking
===============

Preparation
-----------

Download the skeleton provided in Judge. **Do not** change the **StartUp** class
or its **namespace**.

Problem description
-------------------

Your task is to create a repository which stores cars by creating the classes
described below.

First, write a C\# class **Car** with the following properties:

-   **Make: string**

-   **Model: string**

-   **HorsePower: int**

-   **RegistrationNumber: string**

| **public class** Car {                                 |
| *// TODO: implement this class*                        |
| }                                                      |
|--------------------------------------------------------|


The class **constructor** should receive **make, model, horsePower and
registrationNumber** and override the **ToString()** method in the following
format:

**"Make: {make}"**

**"Model: {model}"**

**"HorsePower: {horse power}"**

**"RegistrationNumber: {registration number}"**

Write a C\# class **Parking** that has **cars** (a collection which stores the
entity **Car**). All entities inside the class have the **same properties**.

| **public class** Parking {                                 |
| *// TODO: implement this class*                            |
| }                                                          |
|------------------------------------------------------------|


The class **constructor** should initialize the **cars** with a new instance of
the collection and accept capacity as parameter**.** Implement the following
features:

-   Field **cars** – **collection** that holds added cars

-   Field **capacity** – accessed only by the base class (responsible for the
    parking capacity)

-   Method **AddCar(Car car)** – first checks if there is already a car with tha
    provided car registration number and if there is the method returns the
    following message:

    "Car with that registration number, already exists!"

    Next checks if the count of the cars in the parking is more than the
    capacity and if it is returns the following message:

    "Parking is full!"

    Finally if nothing from the previous conditions is true it just adds the
    current car to the cars in the parking and returns the message:

    "Successfully added new car {Make} {RegistrationNumber}"

-   Method **RemoveCar(string registrationNumber)** – removes a car with the
    given registration number. If the provided registration number does not
    exist returns the message:

    "Car with that registration number, doesn't exist!"

    Otherwise, removes the car and returns the message:

    "Successfully removed {registrationNumber}"

-   Method **GetCar(string registrationNumber)** – returns the **Car** with the
    provided registration number

-   Method **RemoveSetOfRegistrationNumber(List\<string\> registrationNumbers)**
    – void method, which removes all cars having the provided registration
    numbers. Each car is removed only if the registration number exists

-   Getter **Count** – returns the number of stored cars.

Examples
--------

This is an example how the **Parking** class is **intended to be used**.

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| var car = new Car("Skoda", "Fabia", 65, "CC1856BG"); var car2 = new Car("Audi", "A3", 110, "EB8787MN"); Console.WriteLine(car.ToString()); //Make: Skoda //Model: Fabia //HorsePower: 65 //RegistrationNumber: CC1856BG var parking = new Parking(5); Console.WriteLine(parking.AddCar(car)); //Successfully added new car Skoda CC1856BG Console.WriteLine(parking.AddCar(car)); //Car with that registration number, already exists! Console.WriteLine(parking.AddCar(car2)); //Successfully added new car Audi EB8787MN Console.WriteLine(parking.GetCar("EB8787MN").ToString()); //Make: Audi //Model: A3 //HorsePower: 110 //RegistrationNumber: EB8787MN Console.WriteLine(parking.RemoveCar("EB8787MN")); //Successfullyremoved EB8787MN Console.WriteLine(parking.Count); //1 |

Submission
----------

Zip all the files in the project folder accept **bin** and **obj** folders.
