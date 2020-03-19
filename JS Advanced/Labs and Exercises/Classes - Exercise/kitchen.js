class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        for (let i=0; i<products.length; i++) {
            let [name, quantity, price] = products[i].split(" ");

            if (this.budget - Number(price) >= 0) {
                if (this.productsInStock[name]) {
                    this.productsInStock[name] += Number(quantity);
                } else {
                    this.productsInStock[name] = Number(quantity);
                }

                this.budget -= Number(price);
                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.actionsHistory.join("\n").trim();
    }

    addToMenu(meal, neededProducts, price) {
        if (this.menu[meal]) {
            return `The ${meal} is already in our menu, try something different.`;
        }

        this.menu[meal] = {
            products: neededProducts,
            price: Number(price)
        };

        return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
    }

    showTheMenu() {
        let result = "";

        for (const key of Object.keys(this.menu)) {
            result += `${key} - $ ${this.menu[key].price}\n`;
        }

        if (result.length === 0) {
            return "Our menu is not ready yet, please come later...";
        }

        return result;
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const line of neededProducts) {
            let items = line.split(" ");
            let [name, quantity] = [items[0], Number(items[1])];

            if (this.productsInStock[name] < quantity || !this.productsInStock[name]) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        for (let line of neededProducts) {
            let [name, quantity] = line.split(" ");

            this.productsInStock[name] -= Number(quantity);
        }

        this.budget += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}