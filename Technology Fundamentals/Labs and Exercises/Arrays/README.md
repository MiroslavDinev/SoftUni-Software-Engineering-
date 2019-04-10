Lab: Arrays
===========

Problems for exercises and homework for the ["Technology Fundamentals" course \@
SoftUni](https://softuni.bg/courses/technology-fundamentals).

You can check your solutions here: <https://judge.softuni.bg/Contests/1202>

Day of Week
-----------

Enter a day number [1…7] and print the name (in English) or "Invalid day!"

### Examples

| **Input** | **Output**   |
|-----------|--------------|
| 1         | Monday       |
| 2         | Wednesday    |
| 10        | Invalid day! |

Print Numbers in Reverse Order
------------------------------

Read n numbers and print them in reverse order.

### Examples

| **Input**  | **Output** |
|------------|------------|
| 3 10 20 30 | 30 20 10   |
| 3 30 20 10 | 10 20 30   |
| 1 10       | 10         |

### <br>Hints

First, we need to read **n** from the console.

![](media/950da07aba9c0eee69d34d724175b5d2.png)

Create an **array of integer** with **n** size.

![](media/bef35461290748f4be3bbc770006a4be.png)

Read **n** numbers using for loop.

![](media/193d61a230e5fad5a21d6b0e8ae2c75a.png)

**Set** number to the corresponding **index**.

![](media/3f71a1db19d6550317325c03ba1398a8.png)

Print the array in reversed order.

![](media/0c5e9a5169658ede2304598aec70d93e.png)

Rounding Numbers
----------------

Read an array of real numbers (space separated), round them in "**away from 0**"
style and print the output as in the examples:

### Examples

| **Input**                  | **Output**                                                   |
|----------------------------|--------------------------------------------------------------|
| 0.9 1.5 2.4 2.5 3.14       | 0.9 =\> 1 1.5 =\> 2 2.4 =\> 2 2.5 =\> 3 3.14 =\> 3           |
| \-5.01 -1.599 -2.5 -1.50 0 | \-5.01 =\> -5 -1.599 =\> -2 -2.5 =\> -3 -1.50 =\> -2 0 =\> 0 |

Reverse Array of Strings
------------------------

Read an array of strings (space separated values), reverse it and print its
elements:

### Examples

| **Input**   | **Output** |
|-------------|------------|
| a b c d e   | e d c b a  |
| \-1 hi ho w | w ho hi -1 |

Sum Even Numbers
----------------

Read an array from the console and sum only the even numbers.

### Examples

| **Input**   | **Output** |
|-------------|------------|
| 1 2 3 4 5 6 | 12         |
| 3 5 7 9     | 0          |
| 2 4 6 8 10  | 30         |

### Hints

First, we need to read the array.

![](media/850cf9ee1fd54c15458f0a7a2cd63390.png)

We will need a variable for the sum.

![](media/c0734539f8f0a005172a028b2c407335.png)

Iterate through all elements in the array with for loop.

![](media/b3d0055dfdb67bdfbc68dbabbf742677.png)

Check if the number at current index is even.

![](media/a257d2fa78bd00c7c33379037a2d01ef.png)

Print the total sum

![](media/b1c3f9f7c0ced3b8076b31bd5b0b8f68.png)

Even and Odd Subtraction
------------------------

Write a program that calculates the difference between the sum of the even and
the sum of the odd numbers in an array.

### Examples

| **Input**   | **Output** | **Comments**                                               |
|-------------|------------|------------------------------------------------------------|
| 1 2 3 4 5 6 | 3          | Even: 2 + 4 + 6 = 12 Odd: 1 + 3 + 5 = 9 Result: 12 – 9 = 3 |
| 3 5 7 9     | \-24       | Even: 0 Odd: 3 + 5 + 7 + 9 = 24 Result: 0 – 24 = -24       |
| 2 4 6 8 10  | 30         | Even: 2 + 4 + 6 + 8 + 10 = 30 Odd: 0 Result: 30 – 0 = 30   |

### Hints

First, we need to read the array.

![](media/650bd2776fe5cde9e3a53a046760ac68.png)

We will need two variables – even and odd sum.

![](media/b776d6a9e4b2ad32b12eeb3939ee0b2d.png)

Iterate through all elements in the array with for loop.

![](media/b3d0055dfdb67bdfbc68dbabbf742677.png)

Check the current number – if it is even add it to the even sum, otherwise add
It to the odd sum.

![](media/1a347953b4cdc3398b8db9d5f565806b.png)

Print the difference.

![](media/041d5e4a9a35da932937e76dc5c2eb01.png)

Equal Arrays
------------

Read two arrays and print on the console whether they are identical or not.
Arrays are identical if their elements are equal. If the arrays are identical
find the sum of the first one and print on the console following message:
"Arrays are identical. Sum: {sum}", otherwise find the first index where the
arrays differ and print on the console following message: "Arrays are not
identical. Found difference at {index} index".

### Examples

| **Input**           | **Output**                                            |
|---------------------|-------------------------------------------------------|
| 10 20 30 10 20 30   | Arrays are identical. Sum: 60                         |
| 1 2 3 4 5 1 2 4 3 5 | Arrays are not identical. Found difference at 2 index |
| 1 10                | Arrays are not identical. Found difference at 0 index |

### Hints

First, we need to read two arrays.

![](media/6374f50e3ade8df6f0a21d92738d363f.png)

Iterate through arrays and compare element. If the elements are not equal print
the required message and break the loop.

![](media/36ba4d2545f2c68a20fb6ce9a3d5c24b.png)

Think about how to solve the other part of the problem.

Condense Array to Number
------------------------

Write a program to read **an array of integers** and **condense** them by
**summing** adjacent couples of elements until a **single integer** is obtained.
For example, if we have 3 elements {2, 10, 3}, we sum the first two and the
second two elements and obtain {2+10, 10+3} = {12, 13}, then we sum again all
adjacent elements and obtain {12+13} = {25}.

### Examples

| **Input** | **Output** | **Comments**                                                               |
|-----------|------------|----------------------------------------------------------------------------|
| 2 10 3    | 25         | 2 10 3 2+10 10+3 12 13 12 + 13 25                                          |
| 5 0 4 1 2 | 35         | 5 0 4 1 2 5+0 0+4 4+1 1+2 5 4 5 3 5+4 4+5 5+3 9 9 8 9+9 9+8 18 17 18+17 35 |
| 1         | 1          | 1 is already condensed to number                                           |

### Hints

While we have more than one element in the array **nums[]**, repeat the
following:

-   Allocate a new array **condensed[]** of size **nums.Length-1**.

-   Sum the numbers from **nums[]** to **condensed[]**:

    -   condensed[i] = nums[i] + nums[i+1]

-   nums[] = condensed[]

The process is illustrated below:

![](media/056442323d83060351527f573cfb6ebd.png)

![](media/a0f907e9cf23cd1f8ff2de93baaa05a1.png)
