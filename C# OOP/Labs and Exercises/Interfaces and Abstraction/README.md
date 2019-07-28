Lab: Interfaces and Abstraction
===============================

Problems for exercises and homework for the ["C\# OOP" course \@
SoftUni"](https://softuni.bg/trainings/2244/csharp-oop-february-2019).

You can check your solutions here:
<https://judge.softuni.bg/Contests/1501/Interfaces-and-Abstraction-Lab>

Shapes
------

**NOTE**: You need a public **StartUp** class with the namespace **Shapes**.

Build hierarchy of interfaces and classes:

![C:\\Users\\david\\Desktop\\WINWORD_2018-02-24_13-45-17.png](media/a818dbc53ab074e90411f9be4fef5a95.png)

You should be able to use the class like this:

| StartUp.cs                                                                                                                                                                                                                                           |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| var radius = int.Parse(Console.ReadLine()); IDrawable circle = new Circle(radius); var width = int.Parse(Console.ReadLine()); var height = int.Parse(Console.ReadLine()); IDrawable rect = new Rectangle(width, height); circle.Draw(); rect.Draw(); |

### Examples

| **Input** | **Output**                                                                                                      |
|-----------|-----------------------------------------------------------------------------------------------------------------|
| 3 4 5     | \*\*\*\*\*\*\* \*\* \*\* \*\* \*\* \* \* \*\* \*\* \*\* \*\* \*\*\*\*\*\*\* \*\*\*\* \* \* \* \* \* \* \*\*\*\* |

### Solution

The algorithm for drawing a circle is:

![](media/ce0987eaeed2afc66803b9a0207c1c7e.png)

The algorithm for drawing a rectangle is:

![](media/c543fdac730322fa8df0519e6dddabcf.png)

Cars
----

**NOTE**: You need a public **StartUp** class with the namespace **Cars**.

Build a hierarchy of interfaces and classes:

![C:\\Users\\david\\Desktop\\WINWORD_2018-02-24_13-53-46.png](media/f3a7cac739428a604f45ee797cfe1a42.png)

Your hierarchy must be used with this code:

| StartUp.cs                                                                                                                                                  |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ICar seat = new Seat("Leon", "Grey"); ICar tesla = new Tesla("Model 3", "Red", 2); Console.WriteLine(seat.ToString()); Console.WriteLine(tesla.ToString()); |

### Examples

| **Output**                                                                                   |
|----------------------------------------------------------------------------------------------|
| Grey Seat Leon Engine start Breaaak! Red Tesla Model 3 with 2 Batteries                      |
| Engine start Breaaak!                                                                        |
