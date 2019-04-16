Lab: Dictionaries, Lambda and LINQ
==================================

Problems for exercises and homework for the ["Technology Fundamentals" course \@
SoftUni](https://softuni.bg/courses/technology-fundamentals).

You can check your solutions here: <https://judge.softuni.bg/Contests/1212>

Associative Arrays
==================

Count Real Numbers
------------------

Read a **list of integers** and **print them in ascending order** along with
their **number of occurrences**.

### Examples

| **Input** | **Output**      |   | **Input** | **Output**              |   | **Input** | **Output**                |
|-----------|-----------------|---|-----------|-------------------------|---|-----------|---------------------------|
| 8 2 2 8 2 | 2 -\> 3 8 -\> 2 |   | 1 5 1 3   | 1 -\> 2 3 -\> 1 5 -\> 1 |   | \-2 0 0 2 | \-2 -\> 1 0 -\> 2 2 -\> 1 |

### Hints

Read an array from doubles

![](media/472075d68dffbd0b94fe4d37e8b99a93.png)

Use **SortedDictionary\<double, int\>** named **counts**.

![](media/0f87ff80fd242c5180792c219812d46e.png)

Pass through each input number **num** and increase **counts[num]** (when
**num** exists in the dictionary) or assign **counts[num]** = **1** (when
**num** does not exist in the dictionary).

![](media/b0452ad716c2caf688f7804f403ba311.png)

Pass through all numbers in the dictionary and print the number **num** and its
count of occurrences.

![](media/b5bf46d34efd70708b549b54303090c8.png)

Odd Occurrences
---------------

Write a program that extracts from a given sequence of words all elements that
present in it **odd number of times** (case-insensitive).

-   Words are given in a single line, space separated.

-   Print the result elements in lowercase, in their order of appearance.

### Examples

| **Input**                      | **Output** |
|--------------------------------|------------|
| Java C\# PHP PHP JAVA C java   | java c\# c |
| 3 5 5 hi pi HO Hi 5 ho 3 hi pi | 5 hi       |
| a a A SQL xx a xx a A a XX c   | a sql xx c |

### Hints

Read a line from the console and split it by a space

![](media/08c15f6976a73bd9379cf8f7c8fb4b04.png)

Use a **dictionary** (**string int**) to count the occurrences of each word

![](media/510e78327875f9838569671eb1e7dc00.png)

Pass through all elements in the array and count each word.

![](media/220c282bbd8e27994c7966114815edd5.png)

Pass through the dictionary and print words that occures odd times.

![](media/8e7c145cdfb0b54b32b73e64bb9eab7e.png)

Word Synonyms
-------------

Write a program which keeps a dictionary with synonyms. The **key** of the
dictionary will be the **word**. The **value** will be a **list of all the
synonyms of that word**. You will be given a number **n**. On the next **2 \*
n** lines you will be given a **word** and a **synonym** each on a separate line
like this:

-   {**word**}

-   {**synonym**}

If you get the same word twice just add the new synonym to the list.

Print the words in the following format:

**{word} - {synonym1, synonym2… synonymN}**

### Examples

| **Input**                                  | **Output**                               |
|--------------------------------------------|------------------------------------------|
| 3 cute adorable cute charming smart clever | cute - adorable, charming smart - clever |
| 2 task problem task assignment             | task – problem, assignment               |

### Hints

-   Use **dictionary (string -\> List\<string\>)** to keep track of all words

![](media/629e10008060b887c4f9c5433d2f9246.png)

-   **Read n \* 2 lines**

-   **Add the word in the dictionary if it is not present**

![](media/1993f13c37f188c1bc7eb73520323a23.png)

-   **Add the synonym as value to the given word**

![](media/277db1d9874d6e8a6c9d72a7ab549063.png)

-   Print each word with the synonyms in the required format

LINQ
====

Largest 3 Numbers
-----------------

Read a **list of integers** and **print largest 3 of them**. If there are less
than 3, print all of them.

### Examples

| **Input**        | **Output** |   | **Input** | **Output** |
|------------------|------------|---|-----------|------------|
| 10 30 15 20 50 5 | 50 30 20   |   | 20 30     | 30 20      |

### Hints

-   Read an array of integers

-   **Order the array using LINQ query**

![](media/7062c2b18cd7f3d64d8c4101156686eb.png)

-   **Print top 3 numbers with for loop**

Word Filter
-----------

Read an array of strings, take only words which length is even. Print each word
on a new line.

### Examples

| **Input**                | **Output**         |
|--------------------------|--------------------|
| kiwi orange banana apple | kiwi orange banana |
| pizza cake pasta chips   | cake               |

-   Read an array of strings

-   Filter those whose length is even

![](media/45552b8d911dacc7c6fb7f5d999d79d7.png)

-   Print each word on a new line
