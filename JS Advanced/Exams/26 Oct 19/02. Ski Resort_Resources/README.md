JS Advanced - Exam: 26.10.2019
==============================

Exam problem for the [“JavaScript Advanced” course \@
SoftUni](https://softuni.bg/courses/javascript-advanced).  
Submit your solutions in the SoftUni Judge system at
<https://judge.softuni.bg/Contests/Compete/Index/1850#1>.

Problem 2. Ski Resort
---------------------

Use the provided **SkiResort class** to solve this problem.

### Your Task

Using **Mocha** and **Chai** write **JS Unit Tests** to test the entire
functionality of the **Ski Resort class**. Make sure instances of it have all
the required functionality and validation. You may use the following code as a
template:

| describe(**"Tests …"**, **function**() { describe(**"TODO …"**, **function**() {                                                                         |
| *it*(**"TODO …"**, **function**() { *// TODO:* … }); });                                                                                                 |
| *// TODO:* … });                                                                                                                                         |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|


### Functionality

**solution.js** defines a **class** that contains information about a **ski
resort**. An **instance** of the class should support the following operations:

-   **Instantiation** with **one parameter** - a **string** representing the
    **ski resort name,** and an **additional properties** called
    "**voters**"(**number** with **value 0 by default**) and "**hotels**" (
    **empty array by default)**.

-   Getter **bestHotel** - **Returns** the best hotel in a given format or if
    there is **no votes** yet **return** a proper **message**

-   Function **build()** - receives **two** parameters: a **string**
    (**hotelName**) and a **number** (**beds**). If the **name** is **empty
    string** or the **beds** are **less than 1** an **error** should be
    **thrown** . Otherwise the function should add the hotel to the hotels array
    and **return the proper message**.

-   Function **book()** receives **two** parameters: a **string**
    (**hotelName**) and a **number** (**beds**)**.** If the name is valid and
    there are free beds in that hotel you should decrease the number beds of the
    hotel with the given beds you want to book. If booking is **successful** you
    should **return** the **proper message**, otherwise an **error** should be
    thrown.

-   Function **leave()** - receives three parameters: a **string**
    (**hotelName**) and **two** numbers - **beds** and **points**. If the
    parameters are valid and there is a hotel with that name the proper
    **message** should be **returned**. Otherwise **throw** an **error**.

-   Function **averageGrade()** - receives **no** parameters - if there **aren’t
    any votes** the proper **message** should be **returned**. Otherwise,
    **return** the average grade of all the hotels in the **proper format**.

### Examples

| Sample Code Usage                                                                                                                                                                                                                                                                                                                                                                                |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| let res = new SkiResort("Some"); console.log(res.build("Sun", 10)); console.log(res.build('Avenue',5)) console.log(res.book('Sun', 5)) console.log(res.book('Avenue', 5)) console.log(res.leave('Sun', 3, 2)); console.log(res.leave('Avenue', 3, 3)); console.log(res.book('Avenue', 3)) console.log(res.leave('Avenue', 3, 0.5)); console.log(res.averageGrade()); console.log(res.bestHotel); |
| Corresponding Output                                                                                                                                                                                                                                                                                                                                                                             |
| **Successfully built new hotel - Sun Successfully built new hotel - Avenue Successfully booked Successfully booked 3 people left Sun hotel 3 people left Avenue hotel Successfully booked 3 people left Avenue hotel Average grade: 1.83 Best hotel is Avenue with grade 10.5. Available beds: 3**                                                                                               |

### Submission

Submit your tests inside a **describe()** statement, as shown above.
