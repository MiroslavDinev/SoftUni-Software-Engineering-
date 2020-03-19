function solve(arr){
    let juices = {};
    let bottles = {};

    for (const entry of arr) {
        let [juice, quantity] = entry.split(" => ");
        quantity = Number(quantity);

        if(!juices.hasOwnProperty(juice)){
            juices[juice] = 0;
        }

        juices[juice] += quantity;

        let currQty = juices[juice];

        if(currQty>=1000){
            bottles[juice] = Math.trunc(currQty / 1000);
        }
    }

    for (const key in bottles) {
        console.log(`${key} => ${bottles[key]}`);
    }
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);