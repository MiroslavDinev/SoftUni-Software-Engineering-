**Problem.1 Arriving in Kathmandu**

*Your friend is a mountaineer and he needs your help. Your first task is to find
him, so you went to Kathmandu and found some notes at his quarters.*

![](media/dea682478f8f890b9cb17e220d25a5df.png)

Write a program that **decrypts messages**, which contain information about
coordinates. You are looking for **names of peaks** in the Himalayas and their
[geohash](https://en.wikipedia.org/wiki/Geohash) coordinates. Keep reading lines
until you receive the "**Last note**" message.

Here is your **cipher**:

-   **Name of the peak**

    -   It is consisted of **letters (upper and lower), numbers** and some of
        the following characters between its letters – "**!**" "**\@**" "**\#**"
        "**\$**" "**?**". Example for valid names: “!\@K?\#2!\#” (K2).

-   **The length of the geohashcode**

    -   Begins **after** the "**=**" (equals) sign and is consisted only of
        numbers.

-   **The geohash code**

    -   Begins after these symbols – "**\<\<**", may contain anything and the
        message always ends with it.

**Examples for valid input:**

"!Ma\$\$ka!lu!\@=9\<\<ghtucjdhs" – all the components are there – **name of the
peek**, **length** of the geohashcode and a **geohashcode**.

"!\@Eve?\#rest!\#=7\<\<vbnfhfg"

**Examples of invalid input:**

"anna\@fg\<\<jhsd\@bx!=4" – **their order is wrong**. The name should be first,
the length after and the code last.

"\#n...s!n-\<\<tyuhgf4" – **the length is missing** and the **name contains
dots.**

**"**Nan\$ga!Parbat=8\<\<gh2tn – **the length** of the geohash code doesn't
match the given number.

The **geohash code** you are looking for is with **length exactly** as much as
the **given length** in the message and the information must be in the **exact
given order**, otherwise it is considered **invalid**. If you find it, print the
following message:

"**Coordinates found! {nameOfMountain} -\> {geohashcode}**"

Otherwise print: “**Nothing found!**” after every **invalid** message.

Input / Constraints
-------------------

-   You will be receiving strings until you get the “**Last note**” message.

Output
------

-   If you find the right coordinates, print: "**Coordinates found!
    {nameOfMountain} -\> {geohashcode}**".

-   If the message is invalid, print: "**Nothing found!**".

Examples
--------

| **Input**                                                                                                                                                                                                                                                                                                                                                                                                                                                              | **Output**                                                                                                    |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| !\@Ma?na?sl!u\@=7\<\<tv58ycb4845 E!ve?rest=.6\<\<tuvz26 !K\@2.,\#\#\$=4\<\<tvnd !Shiha\@pan\@gma\#\#9\<\<tgfgegu67 !\#\#\#Anna\@pur\@na\#\#=16\<\<tv5dekdz8x11ddkc Last note                                                                                                                                                                                                                                                                                           | Nothing found! Nothing found! Nothing found! Nothing found! Coordinates found! Annapurna -\> tv5dekdz8x11ddkc |
| **Comments**                                                                                                                                                                                                                                                                                                                                                                                                                                                           |                                                                                                               |
| The first line is invalid, because the length – **7**, **doesn't match** the **length** of the **code**. The second line is invalid, because the **length** should be consisted **only** of **numbers**. The third line is invalid, because the name contains **symbols** that are **not** allowed – **".", ",".** The forth line is invalid, because the **"="** sign before the length is **missing**. The fifth line is valid, so we print the appropriate message. |                                                                                                               |
|                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |                                                                                                               |
| Ka?!\#nch\@\@en\@ju\#\#nga\@=3\<\<thfbghvn =9Cho?\@\#Oyu\<\<thvb7ydht Nan??ga\#Par!ba!t?=16\<\<twm03q2rx5hpmyr6 Dhau??la\#gi\@ri?!\#=3\<\<bvnfhrtiuy Last note                                                                                                                                                                                                                                                                                                         | Nothing found! Nothing found! Coordinates found! NangaParbat -\> twm03q2rx5hpmyr6 Nothing found!              |

**Problem 2. On the Way to Annapurna**

*You’ve hired a Sherpa and he has a list of supplies you both need to go on the
way. He has passed you some notes and you have to order them correctly in a
diary before you start circling around the town’s stores.*

![](media/dea682478f8f890b9cb17e220d25a5df.png)

Create a program, that lists **stores** and the **items** that can be found in
them. You are going to be receiving **commands** with the information you need
until you get the "**End**" command. There are **three possible commands**:

-   "**Add**-\>{Store}-\>{Item}"

    -   **Add** the **store** and the **item** in your diary. If the store
        already **exists**, add just the item.

-   **"Add**-\>{Store}-\>{Item},{Item1}…,{ItemN}"

    -   **Add the store and the items to** your notes. **If the store already
        exists** in the diary – **add just the items** to it.

-   "**Remove**-\>{Store}"

    -   **Remove the store** and its items from your diary, **if it exists**.

In the end, print the collection **sorted by the count of the items** in
**descending order** and **then by the names of the stores**, again, **in
descending order** in the following format:

**Stores list:**

**{Store}**

**\<\<{Item}\>\>**

**\<\<{Item}\>\>**

**\<\<{Item}\>\>**

Input / Constraints
-------------------

-   You will be receiving information until the “**END**” command is given.

-   There will always be **at least one** store in the diary.

-   Input will always be **valid**, there is no need to check it explicitly.

Output
------

-   Print the list of stores in the format given above.

Examples
--------

| **Input**                                                                                                                                                                                                                                                                                                                                                            | **Output**                                                                                                                                                   |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Add-\>PeakSports-\>Map,Navigation,Compass Add-\>Paragon-\>Sunscreen Add-\>Groceries-\>Dried-fruit,Nuts Add-\>Groceries-\>Nuts Add-\>Paragon-\>Tent Remove-\>Paragon Add-\>Pharmacy-\>Pain-killers END                                                                                                                                                                | Stores list: PeakSports \<\<Map\>\> \<\<Navigation\>\> \<\<Compass\>\> Groceries \<\<Dried-fruit\>\> \<\<Nuts\>\> \<\<Nuts\>\> Pharmacy \<\<Pain-killers\>\> |
| **Comments**                                                                                                                                                                                                                                                                                                                                                         |                                                                                                                                                              |
| First, we receive the "**Add**" command with a couple of items and we have to add the store and the items to. We keep doing that for each line of input and when we receive the "**Remove**" command, we delete the store and its items from our records. In the end we print the stores sorted by the **count** of their **items** and **then by** their **names**. |                                                                                                                                                              |
|                                                                                                                                                                                                                                                                                                                                                                      |                                                                                                                                                              |
| Add-\>Peak-\>Waterproof,Umbrella Add-\>Groceries-\>Water,Juice,Food Add-\>Peak-\>Tent Add-\>Peak-\>Sleeping-Bag Add-\>Peak-\>Jacket Add-\>Groceries-\>Lighter Remove-\>Groceries Remove-\>Store END                                                                                                                                                                  | Stores list: Peak \<\<Waterproof\>\> \<\<Umbrella\>\> \<\<Tent\>\> \<\<Sleeping-Bag\>\> \<\<Jacket\>\>                                                       |
