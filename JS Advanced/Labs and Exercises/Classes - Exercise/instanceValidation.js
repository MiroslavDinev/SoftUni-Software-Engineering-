class CheckingAccount {
    _clientId;
    _email;
    _firstName;
    _lastName;
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(value) {
        let result = value.match(/^\d{6}$/g);
        if (!result) {
            throw new TypeError("Client ID must be a 6-digit number");
        }

        this._clientId = value;
    }

    get email() {
        return this._email;
    }

    set email(value) {
        let result = value.match(/^[A-Za-z0-9]+@[A-Za-z\.]+$/g);
        if (!result) {
            throw new TypeError("Invalid e-mail");
        }

        this._email = value;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError("First name must be between 3 and 20 characters long");
        }
        let result = value.match(/^[A-Za-z]{3,20}$/g);
        if (!result) {
            throw new TypeError("First name must contain only Latin characters");
        }

        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError("Last name must be between 3 and 20 characters long");
        }
        let result = value.match(/^[A-Za-z]{3,20}$/g);
        if (!result) {
            throw new TypeError("Last name must contain only Latin characters");
        }

        this._lastName = value;
    }
}