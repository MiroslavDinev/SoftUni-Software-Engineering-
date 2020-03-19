**JS Advanced – Exam: 23.02.2020**

Exam problem for the [“JavaScript Advanced” course \@
SoftUni](https://softuni.bg/courses/javascript-advanced).

Problem 2. Parser
-----------------

Use the provided **Parser class** to solve this problem.

### Your Task

Using **Mocha** and **Chai** write **JS Unit Tests** to test the entire
functionality of the **Parser class**. Make sure instances of it have all the
required functionality and validation. You may use the following code as a
template:

| describe(**"Tests …"**, **function**() { describe(**"TODO …"**, **function**() {                                                                         |
| *it*(**"TODO …"**, **function**() { *// TODO:* … }); });                                                                                                 |
| *// TODO:* … });                                                                                                                                         |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|


### Functionality

**solution.js** defines a **class** that contains information about a **parser
class**. An **instance** of the class should support the following operations:

-   **Instantiation** with **one parameter** - a string representing the **data
    to be parsed,** and an **additional properties** called "**log**"( **empty
    array by default**) and a "**addToLog**" ( **function with default value of
    the counter 0)**.

-   Getter **data** - **Returns** the data array

-   Function **print()** - Receives no parameters. Adds an entry in the log
    array and prints the data in a given format.

-   Function **addEntries(entries)** receives **one** parameter: a **string**
    (**entries**)**.** It should parse the entries string and add every entry to
    the data array as an object. For more information see the examples below. It
    should add to the log array the "addEntries" string in the proper format.
    The function should return the "Entries added!".

-   Function **removeEntry(key)** - receives one parameter: a **string**
    (**key**). If there is an object in the data array with the property equal
    to the key, you should add a property "deleted: true" to it. Otherwise an
    error should be thrown, with the following message: "There is no such
    entry!" . If the entry is set to deleted properly, you should add the
    "removeEntry" string in the proper format and return the following message:
    "Removed correctly!" .

-   Function **addToLog(command)** - receives **one** parameter - You should add
    to the log array the command message and increase the counter.

### Examples

| Sample Code Usage                                                                                                                                                                                                                                                                                                                                                                                                                  |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]'); console.log(parser.addEntries("Steven:tech-support Edd:administrator")); console.log(parser.data); console.log(parser.removeEntry("Kate")); console.log(parser.data); console.log("_".repeat(50)); console.log(); console.log(parser.print());                                                                                           |
| Corresponding Output                                                                                                                                                                                                                                                                                                                                                                                                               |
| **Entries added! [ { Nancy: 'architect' }, { John: 'developer' }, { Kate: 'HR' }, { Steven: 'tech-support' }, { Edd: 'administrator' } ] Removed correctly! [ { Nancy: 'architect' }, { John: 'developer' }, { Steven: 'tech-support' }, { Edd: 'administrator' } ] \_________________________________________________\_ id\|name\|position 0\|Nancy\|architect 1\|John\|developer 2\|Steven\|tech-support 3\|Edd\|administrator** |

### Submission

Submit your tests inside a **describe()** statement, as shown above.
