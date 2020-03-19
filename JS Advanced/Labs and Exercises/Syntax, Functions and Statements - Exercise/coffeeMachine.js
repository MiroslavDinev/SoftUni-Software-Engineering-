function solve(arr) {
    let totalIncome = 0;
    let coffeeTypes = {
        "caffeine": 0.80,
        "decaf": 0.90
    };


    for (let currentOrder of arr) {
        let price = 0;
        currentOrder = currentOrder.split(", ");
        let coins = Number(currentOrder[0]);
        let drinkType = currentOrder[1];

        if (drinkType === "coffee") {
            let coffeeType = currentOrder[2];
            price += coffeeTypes[coffeeType];
        } else {
            price += 0.80;
        }

        if (currentOrder.includes("milk")) {
            let milkPrice = Number((price * 0.1).toFixed(1));
            price += milkPrice;
        }

        let sugar = Number(currentOrder.pop());

        if (sugar) {
            price += 0.10;
        }

        if (coins >= price) {
            totalIncome += price;
            console.log(`You ordered ${drinkType}. Price: $${price.toFixed(2)} Change: $${(coins-price).toFixed(2)}`);
        } else {
            console.log(`Not enough money for ${drinkType}. Need $${(price-coins).toFixed(2)} more`);
        }
    }

    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);