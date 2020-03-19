class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.libraryName.length,
            special: (this.libraryName.length) * 2,
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes.hasOwnProperty(type)) {
            throw new Error(`The type ${type} is invalid`);
        }

        let subscriber = this.subscribers.find(s => s.name === name);

        if (!subscriber) {
            subscriber = {
                name,
                type,
                books: []
            };

            this.subscribers.push(subscriber);
        }
        else {
            subscriber["type"] = type;
        }

        return subscriber;
    }

    unsubscribe(name) {
        let subscriber = this.subscribers.find(s => s.name === name);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers = this.subscribers.filter(s => s.name !== name);

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let subscriber = this.subscribers.find(s => s.name === subscriberName);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        let subscriptionType = subscriber.type;
        let typeLimit = this.subscriptionTypes[subscriptionType];

        if (subscriber.books.length + 1 > typeLimit) {
            throw new Error(`You have reached your subscription limit ${typeLimit}!`);
        }
        else {
            subscriber.books.push({ title: bookTitle, author: bookAuthor });
        }

        return subscriber;
    }

    showInfo() {
        if (this.subscribers.length == 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }

        return this.subscribers
        .map(s=>
            `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${s.books
        .map(b=>`${b.title} by ${b.author}`)
        .join(", ")}`)
        .join("\n");
    }
}