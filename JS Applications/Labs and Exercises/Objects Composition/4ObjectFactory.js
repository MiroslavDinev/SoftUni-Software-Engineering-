function solve(input) {
    let obj = {};

    let arrOfObjects = JSON.parse(input);
    for (let i = 0; i < arrOfObjects.length; i++) {
        let currObj = arrOfObjects[i];
        for (const key of Object.keys(currObj)) {
            if (!Object.keys(obj).includes(key)) {
                obj[key] = currObj[key];
            }
        }
    }

    return obj;
}

console.log(
    solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`)
);