function solve(arr) {
    let obj = {};
    for (let index = 0; index < arr.length; index += 2) {
        let name = arr[index];
        let = calories = Number(arr[index + 1]);
        obj[name] = calories;
    }

    console.log(obj);
}

solve(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);