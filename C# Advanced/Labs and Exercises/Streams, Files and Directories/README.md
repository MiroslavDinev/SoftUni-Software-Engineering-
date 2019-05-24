Lab: Streams, Files and Directories 
====================================

File Operations
===============

Odd Lines
---------

Write a program that reads a text file and writes it's every **odd** line in
another file. Line numbers starts from 0.

### Examples

| **Input.txt**                                                                                                                                                                                                                                                                                                                                    | **Output.txt**                                                                                                                                                                     |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Two households, both alike in dignity,                                                                                                                                                                                                                                                                                                           | In fair Verona, where we lay our scene, Where civil blood makes civil hands unclean. A pair of star-cross’d lovers take their life; Do with their death bury their parents’ strife |
| In fair Verona, where we lay our scene,                                                                                                                                                                                                                                                                                                          |                                                                                                                                                                                    |
| From ancient grudge break to new mutiny,                                                                                                                                                                                                                                                                                                         |                                                                                                                                                                                    |
| Where civil blood makes civil hands unclean.                                                                                                                                                                                                                                                                                                     |                                                                                                                                                                                    |
| From forth the fatal loins of these two foes                                                                                                                                                                                                                                                                                                     |                                                                                                                                                                                    |
| A pair of star-cross'd lovers take their life;                                                                                                                                                                                                                                                                                                   |                                                                                                                                                                                    |
| Whose misadventured piteous overthrows                                                                                                                                                                                                                                                                                                           |                                                                                                                                                                                    |
| Do with their death bury their parents' strife.                                                                                                                                                                                                                                                                                                  |                                                                                                                                                                                    |

Line Numbers
------------

Write a program that reads a text file and inserts line numbers in front of each
of its lines. The result should be written to another text file.

### Examples

| **Input.txt**                                                                                                                                                                                                                                                                                                                                    | **Output.txt**                         |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------|
| Two households, both alike in dignity,                                                                                                                                                                                                                                                                                                           | Two households, both alike in dignity, |
| In fair Verona, where we lay our scene,                                                                                                                                                                                                                                                                                                          |                                        |
| From ancient grudge break to new mutiny,                                                                                                                                                                                                                                                                                                         |                                        |
| Where civil blood makes civil hands unclean.                                                                                                                                                                                                                                                                                                     |                                        |
| From forth the fatal loins of these two foes                                                                                                                                                                                                                                                                                                     |                                        |
| A pair of star-cross'd lovers take their life;                                                                                                                                                                                                                                                                                                   |                                        |
| Whose misadventured piteous overthrows                                                                                                                                                                                                                                                                                                           |                                        |
| Do with their death bury their parents' strife.                                                                                                                                                                                                                                                                                                  |                                        |

1.  In fair Verona, where we lay our scene,

2.  From ancient grudge break to new mutiny,

3.  Where civil blood makes civil hands unclean.

4.  From forth the fatal loins of these two foes

5.  A pair of star-cross'd lovers take their life;

6.  Whose misadventured piteous overthrows

7.  Do with their death bury their parents' strife.

Word Count
----------

Write a program that reads a list of words from the file **words.txt** and finds
how many times each of the words is contained in another file **text.txt**.
Matching should be **case-insensitive**.

The result should be written to another text file. Sort the words by frequency
in descending order.

### Examples

| **words.txt**  | **Input.txt**                                                                                                           | **Output.txt**             |
|----------------|-------------------------------------------------------------------------------------------------------------------------|----------------------------|
| quick is fault | \-I was quick to judge him, but it wasn't his fault. -Is this some kind of joke?! Is it? -Quick, hide here…It is safer. | is - 3 quick - 2 fault - 1 |

Merge Files
-----------

Write a program that reads the contents of two text files and merges them
together into a third one.

### Examples

| **Input1.txt** | **Input2.txt** | **Output.txt** |
|----------------|----------------|----------------|
| 1 3 5          | 2 4 6          | 1 2 3 4 5 6    |

Slice File
----------

Write a program that slice text file in 4 equal parts.

Name them:

-   Part-1.txt, Part-2.txt, Part-3. txt, Part-4.txt

Directory Operations
====================

Folder Size
-----------

You are given a folder named “TestFolder”. Get the size of all files in the
folder, which are **NOT directories.** The result should be written to another
text file in **Megabytes**.

### Examples

| **Output.txt**   |
|------------------|
| 5.16173839569092 |
