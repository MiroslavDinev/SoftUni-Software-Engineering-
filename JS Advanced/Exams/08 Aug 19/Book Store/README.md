JS Advanced Retake - 08 August 2019
===================================

Exam problem for the [“JavaScript Advanced” course \@
SoftUni](https://softuni.bg/courses/javascript-advanced). Submit your solutions
in the SoftUni Judge system at
<https://judge.softuni.bg/Contests/Compete/Index/1772#1>.

Problem 2. Book Store
---------------------

Use the provided **BookStore class** to solve this problem.

### Your Task

Using **Mocha** and **Chai** write **JS Unit Tests** to test the entire
functionality of the **BookStore class**. Make sure instances of it have all the
required functionality and validation. You may use the following code as a
template:

| describe(**"Tests …"**, **function**() { describe(**"TODO …"**, **function**() {                                                                         |
| *it*(**"TODO …"**, **function**() { *// TODO:* … }); });                                                                                                 |
| *// TODO:* … });                                                                                                                                         |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|


### Functionality

**bookStore.js** defines a **class** that contains information about a **book
store**. An **instance** of the class should support the following operations:

-   **Instantiation** with **one parameter** - a **string** representing the
    **bookstore name,** and an **additional properties** called "**books**" and
    "**workers**" - an **empty arrays by default**.

-   Function **stockBooks()** - receives **one** parameter - **newBooks** (an
    **array** of **strings**). This function adds **each of the elements** from
    the input into the **book's property**.

-   Function **hire()** - receives **two** parameters: a **string** (**name**)
    and another **string** (**position**). If the worker is **already hired**
    the function **throws** an **error**, otherwise the worker is **hired**, and
    a proper **message** is **returned**.

-   Function **fire()** - receives **one** parameter - **workerName.** If there
    is an employee with that name, he is fired, and a proper message is returned
    . Otherwise, an **error** is **thrown**.

-   Function **sellBook()** - receives two parameters: a **string** (**title**)
    and another **string** (**workerName**). If the book is in **stock** and the
    given worker name is **present** in the workers property, the book is
    **sold,** and the current worker **books sold counter** is **increased** by
    1 . Otherwise, an **errors** is **thrown**.

-   Function **printWorkers()** - This function **prints all workers.**

>   *Check the given class for more clarity!*

### Examples

| Sample Code Usage                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| let store = new BookStore('Store'); store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']); console.log(store.hire('George', 'seller')); console.log(store.hire('Ina', 'seller')); console.log(store.hire('Tom', 'juniorSeller')); store.sellBook('Inferno', 'Ina'); store.stockBooks(['Harry Potter-J.Rowling']); console.log(store.fire('Tom')); console.log(store.printWorkers()); |
| Corresponding Output                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| George started work at Store as seller Ina started work at Store as seller Tom started work at Store as juniorSeller Tom is fired Name:George Position:seller BooksSold:0 Name:Ina Position:seller BooksSold:1                                                                                                                                                                                                                                                |

### Submission

Submit your tests inside a **describe()** statement, as shown above.

*GOOD LUCK!*
