JS Advanced Retake - 08 August 2019
===================================

Exam problems for the [JavaScript Essentials” course \@
SoftUni](https://softuni.bg/courses/js-essentials). Submit your solutions in the
SoftUni Judge system at
<https://judge.softuni.bg/Contests/Practice/Index/1772#0>.

Problem 1. BookUni
------------------

### Use the provided skeleton to solve this problem.

### *You can't, and you have no permission to change directly the given html code (index.html file).*

### Your Task

**Write the missing JavaScript code** to make the **Book Store (BookUni)** work
as expected:

-   When **all fields (title, year and price)** are **filled with correct
    input**

    -   **Title** is **non**-**empty strings**

    -   **Year** and **Price** need to be **positive numbers**

-   Upon pressing the **[Add new book] button**, a new book should appear in the
    bookshelf section. Create new **div element** with **class book** (for every
    created book) which hold:

    -   **paragraph** with text content of the given book title and the given
        book year in format: **"{bookTitle} [{bookYear}]"**

    -   **button** with text content "**Buy it only for {bookPrice} BGN**" and
        **functionality** when is being clicked the **current book should be
        removed** from the current section and the **total store profit** is
        **increased** with the given **book price**.

    -   (**only applies to new books**) **button** with text content "**Move to
        old section**" which have the **functionality** when is being clicked
        the current book should be **moved** from the new books section to the
        **old books section**.

### Constraints

Every price should be **rounded** to the **second decimal part (**a.k.a
**toFixed(2)**)

Every **old book price** has **15% discount** from the **initial value** (When
being **created** into the **old books sections** or being **moved** from the
new books section to **the old books section**)

Each **book's year equal** or **higher** than **2000** is consider for a **new
book.**

### Submission

Submit only yours **solve()** function.

### Examples

#### Create a new book

![](media/9403167cb2b73e2954edf1c60698bb29.png)

**After** we hit the **[Add] button**

![](media/3a39a12e42752af4d2115ca733b12de1.png)

![](media/3c41192fa1fb1ec11c7fc0e45f7943a1.png)

#### Create an old book

![](media/17cc66829af9b0840ff8ca38f689f478.png)

![](media/84701ed93e8b96ef0c0bf46b68f8682a.png)

![](media/ed6a6842d7dd8883e44a7733f34b8eee.png)

#### Buy a book

![](media/a3341e53b1c71667c155e9d53929d53a.png)

![](media/9542f2fcbc814baed85bd793a0e93fca.png)

#### Move new book to the old section

![](media/a780ca4e09d8b91772788fd502a479d6.png)

![](media/7d5225427d8cfbf08e665ea5ec5ab2b6.png)

![](media/af5d141fb226bff0808ee503419d8c28.png)

*GOOD LUCK… c(:*
