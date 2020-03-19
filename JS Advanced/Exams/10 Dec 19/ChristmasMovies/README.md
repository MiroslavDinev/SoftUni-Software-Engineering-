JS Advanced – Retake Exam: 10.12.2019
=====================================

Exam problem for the [“JavaScript Advanced” course \@
SoftUni](https://softuni.bg/courses/javascript-advanced).  
Submit your solutions in the SoftUni Judge system at
<https://judge.softuni.bg/Contests/Compete/Index/1933#1>.

Problem 2. Christmas movies
---------------------------

Use the provided **ChristmasMovies class** to solve this problem.

### Your Task

Using **Mocha** and **Chai** write **JS Unit Tests** to test the entire
functionality of the **ChristmasMovies class**. Make sure instances of it have
all the required functionality and validation. You may use the following code as
a template:

| describe(**"Tests …"**, **function**() { describe(**"TODO …"**, **function**() {                                                                         |
| *it*(**"TODO …"**, **function**() { *// TODO:* … }); });                                                                                                 |
| *// TODO:* … });                                                                                                                                         |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|


### Functionality

**movies.js** defines a **class** that contains information about some
**Christmas movies**. An **instance** of the class should support the following
operations:

-   **Instantiation** with **no parameters,** and **properties** called
    "**movieCollection**"(**empty array**), "**watched**" (**empty object)** and
    **“actors” (empty array)**.

-   Method **buyMovie()** - receives **two** parameters: a **string**
    (**movieName**) and an **array (actors)**. If you don’t have the movie in
    your collection, you should add it in in format **{name: movieName, actors:
    [actors]}**, where there are only **unique actors** and return a proper
    message. Otherwise an error should be **thrown**.

-   Method **discardMovie() one** parameter: a **string** (**movieName**)**.**
    If you have the movie in your collection you should delete it and if the
    movie is watched, you should also remove it from the watched list and return
    a proper message. If you don’t have the movie in the collection, an error is
    thrown.

-   Method **watchMovie()** - receives one parameter: a **string**
    (**movieName**). If you have the movie in your collection and is still not
    in the watched list, you should put it there as a key and value pair where
    the movie name is the key and the value is set to 1. However, if it already
    is watched you should just increase the counter. Otherwise, a new error is
    thrown.

-   Method **favouriteMovie()** - receives **no** parameters. If there are no
    movies in your watched list a new error is thrown. Otherwise, a message is
    returned in a proper format.

-   Method **mostStarredActors()** - receives **no** parameters. If there are no
    movies in your collection a new error is thrown. Otherwise, a message is
    returned in a proper format.

### Examples

| Sample Code Usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| let christmas = new ChristmasMovies(); console.log(christmas.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby'])); console.log(christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'])); console.log(christmas.buyMovie('Home Alone 2', ['Macaulay Culkin'])); console.log(christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Rashida Jones'])); christmas.watchMovie('The Grinch'); console.log(christmas.discardMovie('The Grinch')); christmas.watchMovie('Home Alone'); christmas.watchMovie('Home Alone'); christmas.watchMovie('Home Alone'); christmas.watchMovie('Last Christmas'); christmas.watchMovie('Last Christmas'); console.log(christmas.favouriteMovie()); console.log(christmas.mostStarredActor()); |
| Corresponding Output                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **You just got Last Christmas to your collection in which Madison Ingoldsby, Emma Thompson, Boris Isakovic are taking part! You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part! You just got Home Alone 2 to your collection in which Macaulay Culkin are taking part! You just got The Grinch to your collection in which Benedict Cumberbatch, Rashida Jones are taking part! You just threw away The Grinch! Your favourite movie is Home Alone and you have watched it 3 times! The most starred actor is Macaulay Culkin and starred in 2 movies!**                                                                                                                                                                                               |

### Submission

Submit your tests inside a **describe()** statement, as shown above.
