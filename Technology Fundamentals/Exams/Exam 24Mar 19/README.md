Emoji Sumator
=============

Create a program, that finds all of the **emojis** in **a given message** and
makes some calculations. You will receive a few lines of input**.** On the
**first line**, you will receive a single **line of text (ASCII symbols).** On
the **next line**, you will receive an **emoji code** in the following format:

“**number:number:number:(…)**”

**Each number is the value of an ASCII symbol** and if you decrypt **all of the
symbols**, you will receive a name of an emoji.

An emoji is **valid** when:

-   It is surrounded by **colons and consists of at least 4 lowercase letters**
    from the English alphabet.

-   **Before** the emoji there is a **white space** and **after it** there is a
    **white space or any of the following punctuation marks:** ‘,’, ‘.**’, ‘!’,
    ‘?’.**

**Example for valid emojis:**

I hope you have a **:sunny:** day **:smiley: :smiley:**.

You must find all of the emojis and after that, calculate their total power. It
is calculated **by summing the ASCII value of all letters between the colons**.

**Check** if any of the valid **emoji names is equal to the name** received form
**the emoji code** and **if it is – multiply the total emoji power by 2**.

In the end print on the console all valid emojis, **separated by а comma and a
white space in order of finding** and the total emoji power, each on a separate
line.

**Example:**  
**Emojis found: :sunny:, :smiley:, :smiley:**  
**Total Emoji Power: {sum}**

Input / Constraints
-------------------

-   On the first line – the message. **There can be any ASCII character inside
    the input.**

-   Punctuation marks used will be only ‘,’, ‘.**’, ‘!’, ‘?’.**

-   A valid emoji consists of at least **4 lowercase letters surrounded by
    colons**.

Output
------

-   **Print all found emojis, separated by a comma and whitespace.**

-   **Print the sum of all emojis’ power.**

-   Allowed working **time** / **memory**: **100ms** / **16MB**  
    

Examples
--------

| **Input**                                                                                                         | **Output**                                               | **Comment**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|-------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Hello I am Mark from :England: and I am :one: :seven: years old, I have a :hamster: as pet. 115:101:118:101:110   | Emojis found: :seven:, :hamster: Total Emoji Power: 2602 | The only valid emojis here are :seven: and :hamster: because they are longer than 3 symbols and consist only of lowercase letters.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|                                                                                                                   |                                                          | :England: is not a valid emoji because of the upper case ‘E’.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|                                                                                                                   |                                                          | :one: is not a valid emoji because it is shorter than 4 symbols.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|                                                                                                                   |                                                          | Then we sum all letters’ ASCII value:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
|                                                                                                                   |                                                          | ‘h’ = 104, ‘a’ = 97, ‘m’ = 109, ‘s’ = 115, ‘t’ = 116, ‘e’ = 101, ‘r’ = 114. Total for :hamster: is 756.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
|                                                                                                                   |                                                          | Total for :seven: is 545. The total power is 1301.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|                                                                                                                   |                                                          | After that we check if the emoji code corresponds to any emoji, and in this case it does correspond to :seven:, so we multiply the total emoji power and in the end it is 2602.                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| In the Sofia Zoo there are many animals, such as :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox:. 97:101:117:114 | Total Emoji Power: 0                                     | :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox: are all invalid emojis, so we have 0 total emoji power.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |

International SoftUniada
========================

Create a program that lists the results from the International SoftUniada
Competition. You will be receiving input lines in the following format:

“{countryName} -\> {contestantName} -\> {contestantPoints}”

You must calculate the total points of each country, which are the total points
of the contestants from this country. Every contestant can take part in more
than one contest in the SoftUniada and you must keep his total points from the
SoftUniada competition. Each of the contestants are allowed to compete for only
one country. You will be receiving the strings with that information until the
“END” command is given.

In the end, print the countries with their points and their contestants with
their points, ordered by the total points for the countries in descending order,
in the following format:

{country}: {totalPointsForCountry}

\-- {contestantName} -\> {contestantTotalPoints}

\-- {contestantName} -\> {contestantTotalPoints}

{country}: {totalPointsForCountry}

\-- {contestantName} -\> {contestantTotalPoints}

\-- {contestantName} -\> {contestantTotalPoints}

…………………………………………………

### Input / Constraints

-   You will be receiving strings in the format described above until you
    receive the “**END**” command.

-   The **number** of **points** in the **input argument** will be valid
    positive number.

-   There **will** be **no invalid input.**

### Output

-   Print the **countries** with **their total points** and the **contestants
    and their total points** in the format described above, **ordered** by the
    **total points** for the **countries** in **descending** order.

### Examples

| **Input**                                                                                                                                                                                                                                                                                                                                                                                                                            | **Output**                                                                                                                                                                 |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Bulgaria -\> Ivan Ivanov -\> 25 Germany -\> Otto Muller -\> 4 England -\> John Addams -\> 10 Bulgaria -\> Georgi Georgiev -\> 18 England -\> Valteri Bottas -\> 8 Bulgaria -\> Georgi Georgiev -\> 6 END                                                                                                                                                                                                                             | Bulgaria: 49 -- Ivan Ivanov -\> 25 -- Georgi Georgiev -\> 24 England: 18 -- John Addams -\> 10 -- Valteri Bottas -\> 8 Germany: 4 -- Otto Muller -\> 4                     |
| **Comments**                                                                                                                                                                                                                                                                                                                                                                                                                         |                                                                                                                                                                            |
| We receive the first input line and keep the **name** of the **country**, as well as the **contestant** and his **points**. If we have a contestant, who takes part in a **few competitions**, like **Georgi Georgiev**, we have to **add the points** from the second competition to the ones from the first. In the end we have to **order** the collection by the **total points** for the **countries** in **descending order**. |                                                                                                                                                                            |
| Norway -\> Botel Audun -\> 14 Switzerland -\> Alexis Andersson -\> 18 France –\> Francois Arnaud -\> 10 France -\> Pier Armand -\> 22 Bulgaria -\> Peter Petrov -\> 25 France -\> Francois Arnaud -\> 3 Bulgaria -\> Peter Petrov -\> 6 END                                                                                                                                                                                          | France: 35 -- Francois Arnaud -\> 13 -- Pier Armand -\> 22 Bulgaria: 31 -- Peter Petrov -\> 31 Switzerland: 18 -- Alexis Andersson -\> 18 Norway: 14 -- Botel Audun -\> 14 |
