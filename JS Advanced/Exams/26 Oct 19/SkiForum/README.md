JS Advanced: Regular Exam - 26.10.19
====================================

Exam problems for the ["JavaScript Advanced" course \@
SoftUni](https://softuni.bg/courses/js-advanced). Submit your solutions in the
SoftUni Judge system at
[https://judge.softuni.bg/Contests/Compete/Index/](https://judge.softuni.bg/Contests/Compete/Index/1850#2).

Problem 3. Ski Forum
====================

**class** Forum {  
*// TODO: implement this class...*  
}

### Your Task

### Write a Forum class, which supports the described functionality below.

### Functionality

#### constructor()

Should have these **3 private** properties:

-   **users** - empty array

-   **questions - empty array**

-   **id** - **number with initial value 1**

#### register({username}, {password}, {repeatPassword}, {email})

This function should register new user and add it to the users array.

-   If one of the passed parameters is empty string (""), this function should
    throw an error with the following message

"**Input can not be empty"**

-   If password is different from the repeat password, an error with the
    following message should be thrown:

>   **"Passwords do not match"**

-   If an user with such username or email is already registered, an error with
    the following message should be thrown:

>   **"This user already exists!"**

-   If registration is successful the function should return the following
    message:

    **"{username} with {email} was registered successfully!"**

#### login({username}, {password})

This **function** should log in an existing user.

-   If there is no registered user with that username, an error with the
    following message should be thrown:

>   **"There is no such user"**

-   If the username and the password match with those of a registered user, this
    function should return the following message:

>   **"Hello! You have logged in successfully"**

#### logout({username}, {password})

This **function** should log out a logged user.

-   If there is no registered user with that username, an error with the
    following message should be thrown:

>   **"There is no such user"**

-   If the username and the password match with those of a registered user, this
    function should return the following message:

#### "You have logged out successfully"

#### postQuestion({username}, {question})

This function should post a new question with id, equal to the private field's
id value .Every time a new question is added the id is incremented.

-   If there is no user with that username, or he isn't logged in, an error with
    the following message should be thrown:

#### "You should be logged in to post questions"

-   If the question is equal to empty string (""), an error with the following
    message should be thrown:

#### "Invalid question"

-   If a question can be posted, you should add it to the questions array and
    return the following message:

#### "Your question has been posted successfully"

#### postAnswer({username}, {questionId}, {answer})

This function should post an answer to the question with the given id.

-   If there is no user with that username, or he isn't logged in, an error with
    the following message should be thrown:

#### "You should be logged in to post answers"

-   If the answer is equal to empty string (""), an error with the following
    message should be thrown:

#### "Invalid answer"

-   If there is no question with the given id, an error with the following
    message should be thrown:

#### "There is no such question"

The function should return the following message:

#### "Your answer has been posted successfully"

#### showQuestions()

This function should return a sting with all the questions and their answers in
the following format:

#### "Question {id} by {username}: {question}

#### \---{username}: {answer}

#### Question {id} by {username}: {question}

#### \---{username}: {answer}

#### \---{username}: {answer}

#### . . . "

### Submission

Submit only your **Forum class.**

### Examples

This is an example how the code is **intended to be used**:

| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| let forum = new Forum(); forum.register('Michael', '123', '123', 'michael\@abv.bg'); forum.register('Stoyan', '123ab7', '123ab7', 'some\@gmail\@.com'); forum.login('Michael', '123'); forum.login('Stoyan', '123ab7'); forum.postQuestion('Michael', "Can I rent a snowboard from your shop?"); forum.postAnswer('Stoyan',1, "Yes, I have rented one last year."); forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?"); forum.postAnswer('Michael',2, "How old is she?"); forum.postAnswer('Michael',2, "Tell us how tall she is."); console.log(forum.showQuestions()); |
| Corresponding output                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| Question 1 by Michael: Can I rent a snowboard from your shop? ---Stoyan: Yes, I have rented one last year. Question 2 by Stoyan: How long are supposed to be the ski for my daughter? ---Michael: How old is she? ---Michael: Tell us how tall she is.                                                                                                                                                                                                                                                                                                                                                     |
| Sample code usage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| let forum = new Forum(); forum.register('Jonny', '12345', '12345', 'jonny\@abv.bg'); forum.register('Peter', '123ab7', '123ab7', 'peter\@gmail\@.com'); forum.login('Jonny', '12345'); forum.login('Peter', '123ab7'); forum.postQuestion('Jonny', "Do I need glasses for skiing?"); forum.postAnswer('Peter',1, "Yes, I have rented one last year."); forum.postAnswer('Jonny',1, "What was your budget"); forum.postAnswer('Peter',1, "\$50"); forum.postAnswer('Jonny',1, "Thank you :)"); console.log(forum.showQuestions());                                                                          |
| Corresponding output                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| Question 1 by Jonny: Do I need glasses for skiing? ---Peter: Yes, I have rented one last year. ---Jonny: What was your budget ---Peter: \$50 ---Jonny: Thank you :)                                                                                                                                                                                                                                                                                                                                                                                                                                        |

*GOOD LUCK!*
