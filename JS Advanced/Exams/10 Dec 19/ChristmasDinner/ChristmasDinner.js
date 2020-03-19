class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};   
    }

    get budget() {
        return this._budget;
    }
    set budget(value) {
        if(value<0) {
            throw new Error ("The budget cannot be a negative number");
        }

        this._budget = value;
    }

    shopping(product) {
        let productPrice = product[1];
        if(productPrice > this.budget) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(product[0]);
        this.budget -= productPrice;

        return `You have successfully bought ${product[0]}!`;
    }

    recipes(recipe) {
        let { recipeName, productsList } = recipe;
        for (let i = 0; i < productsList.length; i++) {
            let currProduct = productsList[i];
            if(!this.products.includes(currProduct)) {
                throw new Error("We do not have this product");
            }
        }

        let product = {
            recipeName,
            productsList
        };

        this.dishes.push(product);

        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {

        let foundDish = this.dishes.find(x=>x.recipeName===dish);
        if(!foundDish) {
            throw new Error("We do not have this dish");
        }

        if(this.guests.hasOwnProperty(name)) {
            throw new Error("This guest has already been invited");
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let result = "";

        let guestNames = Object.keys(this.guests);
        for (let i = 0; i < guestNames.length; i++) {
            let currGuest = guestNames[i];
            let dish = this.guests[currGuest];
            let foundDish = this.dishes.find(x=>x.recipeName===dish);
            let products = foundDish.productsList;
            result += `${currGuest} will eat ${dish}, which consists of ${products.join(", ")}\n`;
        }

        return result.trim();
    }
}