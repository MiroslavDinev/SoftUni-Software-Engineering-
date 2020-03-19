class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (!username || !password || !repeatPassword || !email) {
            throw new Error("Input can not be empty");
        }

        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }

        let foundUser = this._users.find(x => x.username === username || x.email === email);

        if (foundUser) {
            throw new Error("This user already exists!");
        }

        let newUser = {
            username,
            password,
            email,
            loggedIn: false
        };

        this._users.push(newUser);
        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let foundUser = this._users.find(x => x.username === username);

        if (!foundUser) {
            throw new Error("There is no such user");
        }

        let correctUser = this._users.find(x => x.username === username && x.password === password);

        if (correctUser.loggedIn === false) {
            correctUser.loggedIn = true;
            return "Hello! You have logged in successfully";
        }

    }

    logout(username, password) {
        let foundUser = this._users.find(x => x.username === username);

        if (!foundUser) {
            throw new Error("There is no such user");
        }

        let correctUser = this._users.find(x => x.username === username && x.password === password);

        if (correctUser.loggedIn === true) {
            correctUser.loggedIn = false;
            return "You have logged out successfully";
        }

    }

    postQuestion(username, question) {
        let foundUser = this._users.find(x => x.username === username);

        if (!foundUser) {
            throw new Error("You should be logged in to post questions");
        }

        if (foundUser.loggedIn === false) {
            throw new Error("You should be logged in to post questions");
        }

        if (!question) {
            throw new Error("Invalid question");
        }

        let obj = {
            username,
            question,
            answers: [],
            questionId: this._id,
        };

        this._questions.push(obj);
        this._id++;

        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        let foundUser = this._users.find(x => x.username === username);

        if (!foundUser) {
            throw new Error("You should be logged in to post answers");
        }

        if (foundUser.loggedIn === false) {
            throw new Error("You should be logged in to post answers");
        }

        if (!answer) {
            throw new Error("Invalid answer");
        }

        let foundQuestion = this._questions.find(x => x.questionId === questionId);

        if (!foundQuestion) {
            throw new Error("There is no such question");
        }

        let obj = {
            username,
            answer
        };

        foundQuestion.answers.push(obj);
        return "Your answer has been posted successfully";
    }

    showQuestions() {
        let result = "";

        for (let i = 0; i < this._questions.length; i++) {
            let currQuestion = this._questions[i];
            result += `Question ${currQuestion.questionId} by ${currQuestion.username}: ${currQuestion.question}\n`;
            for (let i = 0; i < currQuestion.answers.length; i++) {
                let currAnswer = currQuestion.answers[i];
                result += `---${currAnswer.username}: ${currAnswer.answer}\n`;
            }
        }

        return result.trim();
    }
}