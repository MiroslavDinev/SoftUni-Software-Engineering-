function solve(input) {
    let result;
    let inputType = typeof input;

    if (inputType === "number") {
        result = (Math.pow(input, 2) * Math.PI).toFixed(2);
    }
    else {
        result = `We can not calculate the circle area, because we received a ${inputType}.`;
    }

    return result;
}

console.log(solve(5));
console.log(solve("name"));