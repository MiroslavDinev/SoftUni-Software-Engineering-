function solve(arr){
    let cars = {};
    for (const entry of arr) {
        let [brand,model, qty] = entry.split(" | ");
        qty = Number(qty);

        if(!cars.hasOwnProperty(brand)){
            cars[brand] = {};
        }

        let carsByBrand = cars[brand];

        if(!carsByBrand.hasOwnProperty(model)){
            carsByBrand[model] = 0;
        }

        carsByBrand[model] += qty;
    }

    let carsBrands = Object.keys(cars);

    for (const currBrand of carsBrands) {
        console.log(currBrand);
        let carsModels = cars[currBrand];
        let carsKeys = Object.keys(carsModels);
        for (const currCar of carsKeys) {
            console.log(`###${currCar} -> ${carsModels[currCar]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);