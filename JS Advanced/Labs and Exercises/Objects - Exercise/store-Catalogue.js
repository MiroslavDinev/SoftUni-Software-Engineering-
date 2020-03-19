function solve(arr){
    let catalogue = {};
    for (const entry of arr) {
        let [name, price] = entry.split(" : ");
        price = Number(price);
        let firstLetter = name[0];

        if(!catalogue.hasOwnProperty(firstLetter)){
            catalogue[firstLetter] = {};
        }

        let products = catalogue[firstLetter];

        if(!products.hasOwnProperty(name)){
            products[name] = price;
        }
    }

    let sortedLetters = Object.keys(catalogue)
    .sort((a,b) => a.localeCompare(b));

    for (const letter of sortedLetters) {
        console.log(letter);
        let products = catalogue[letter];
        let sortedProducts = Object.keys(products).sort((a,b) => a.localeCompare(b));
        for (const currProduct of sortedProducts) {
            console.log(`  ${currProduct}: ${products[currProduct]}`);
        }
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);