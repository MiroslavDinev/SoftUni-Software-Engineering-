Socks
=====

*George is a young poorly organized person and he always have problems with his
socks. He has always dreamed of a program that makes sets of his washed socks.
You are the chosen one to help him with his problem. Good luck!*

First you will be given a sequence of integers representing the left socks.
Afterwards you will be given another sequence of integers representing the right
socks.

Check all of the left socks and right socks in order to make sets. Take **the
last given left sock**, and the **first given right sock** and check **if the
left sock is bigger than the right sock** and if it is – you have to **create a
pair. A pair is created when you add the value of the right sock to the value of
the left one**. If you have a pair, **remove both** the left and the right socks
from their collections.

**If the right sock value is bigger** – **remove the left one and check the next
one**.

If their values **are equal** – **remove the right sock** and **increment** the
value of the left one with **1.**

George wants to wear **the biggest set**, so you have to find out which one it
is.

Afterwards **print the created pairs** from **the first added to the last,**
separated by a space.

### Input

-   On the **first line** of input you will receive the integers, representing
    the left socks, **separated** by a **single space**.

-   On the **second line** of input you will receive the integers, representing
    the **right socks**, **separated** by a **single space**.

### Output

-   On the first line of output - print the biggest pair in the format specified
    above.

-   On the second line - print the pairs, separated by a single space **in the
    order specified above.**

### Constraints

-   All of the given numbers will be valid integers in the range [1, 10000].

-   There will always be at least 1 pair.

-   Allowed time/memory: 100ms/16MB.

### Examples

| **Input**                                 | **Output**         | **Comment**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
|-------------------------------------------|--------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **10 8 7 13 8 4 4 7 3 6 4 12**            | **16 15 16 13 12** | First, we take the last given left sock – 4 and the first given right sock – 4. They are equal, so we have to remove the right sock and increment the left with 1. The left sock becomes 5 and the collection looks like this Left: 10 8 7 13 8 5 Right: 7 3 6 4 12 Next, we take the left with value 5 and the right with value 7 – the right is bigger, so we **remove** the **left** and the collections should look like this: Left: 10 8 7 13 8 Right: 7 3 6 4 12 After that we the left 8 and the right 7 – the left is bigger, so we have our first **pair** with value 15. In the end we have to print the biggest pair, which in this case is with value 16, and the collection of pairs, that we have created. |
| **9 5 4 7 8 5 2 6 9 1 4 5 7 9 6 3 5 4 7** | **16 10 10 15 16** |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |

Problem 2. Excel Functions
==========================

You will receive a table as an input - matrix with several rows and cols. The
first row is the header row. Each header can have some **filter** applied. As a
second parameter you will receive a command. You should execute the command and
print the table **filtered, sorted or modified**.

Commands:

-   hide {header}

If you receive hide command, delete the column with the corresponding header.

-   sort {header}

If you receive sort command, sort the rows in the table by the header given in
**ascending order**. **Note** that the header row should **not** be sorted.

-   filter {header} {value}

If you receive filter command, return the rows with the value given in the
corresponding header.

Input / Constraints
-------------------

You will receive as first parameter multidimensional array of strings, and a
string as second parameter – a command. The input will always be valid.

Output
------

Print on the console each of the table\`s rows; rows elements should be
separated by **" \| ";**

Examples
--------

| **Input**                                                                                                                         | **Output**                                                                        |
|-----------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|
| 4 name, age, grade Peter, 25, 5.00 George, 34, 6.00 Marry, 28, 5.49 sort name                                                     | name \| age \| grade George \| 34 \| 6.00 Marry \| 28 \| 5.49 Peter \| 25 \| 5.00 |
| **Input**                                                                                                                         | **Output**                                                                        |
| 4 firstName, age, grade, course Peter, 25, 5.00, C\#-Advanced George, 34, 6.00, Tech Marry, 28, 5.49, Ruby filter firstName Marry | firstName \| age \| grade \| course Marry \| 28 \| 5.49 \| Ruby                   |

*... Use filters to temporarily hide some of the data in a table, so you can
focus on the data you want ...*

Repository
==========

Preparation
-----------

Download the skeleton provided in Judge. **Do not** change the **StartUp** class
or its **namespace**.

Problem description
-------------------

Write a C\# class **Person that has the following properties:**

-   **Name** – String

-   **Age** – Integer

-   **Birthdate** – DateTime

    The class **constructor** should receive all the properties (**name**,
    **age**, **birthdate**).

| **public class** Person {                                 |
| *// TODO: implement this class*                           |
| }                                                         |
|-----------------------------------------------------------|


Write a C\# class **Repository** that has **data field**, which stores
entities). All entities inside the repository have the **same properties** and a
**unique ID**, that is assigned when they are added **starting from zero**.

| **public class** Repository {                                 |
| *// TODO: implement this class*                               |
| }                                                             |
|---------------------------------------------------------------|


The class **constructor** should initialize the **data** with a new
**Dictionary** instance**.** Implement the following features:

-   Method **Add(Person person)** – adds an entity to the Data;

-   Method **Get(int id)** – returns the entity with given ID

-   Method **Update(int id, Person newPerson)** – replaces the entity with the
    given id with the new entity. Returns false if the id doesn't exist,
    otherwise returns true.

-   Method **Delete(id)** – deletes an entity by given id. Return false if the
    id doesn't exist, otherwise return true.

-   Getter **Count** – returns the number of stored entities

Examples
--------

This is an example how the **Repository** class is **intended to be used**. Make
sure to comment out the parts that throw an error!

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Repository = new Repository(); repository.Add(new Person("George", 10, new DateTime(2009, 05, 04))); repository.Add(new Person("Peter", 5, new DateTime(2014, 05, 24))); Person foundPerson = repository.Get(0); Console.WriteLine(\$"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})"); //George is 10 years old (04/05/2009) Person newPerson = new Person("John", 12, new DateTime(2007, 2, 3)); repository.Update(2, newPerson); // false repository.Update(0, newPerson); // true foundPerson = repository.Get(0); Console.WriteLine(\$"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})"); //John is 12 years old (03/02/2007) Console.WriteLine(repository.Count); // 2 repository.Delete(5); // false repository.Delete(0); // true Console.WriteLine(repository.Count); // 1 |

Constraints
-----------

-   The ID should change **only** when we **add** a new entity.

-   The ID is unique per repository – if two repositories are instantiated, each
    has its own counter.

Submission
----------

Submit **the entire project without bin and obj folders.**
