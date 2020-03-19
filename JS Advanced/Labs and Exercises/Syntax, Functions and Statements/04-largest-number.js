function solve(x, y, z) {
    let result;

    if (x > y && x > z) {
        result = x;
    }

    if (y > x && y > z) {
        result = y;
    }

    if (z > x && z > y) {
        result = z;
    }

    return `'The largest number is ${result}`;
}

console.log(solve(5, -3, 16));
console.log(solve(-3, -5, -22.5));

function solveDec(...params) {
    return `'The largest number is ${params.sort((a, b) => a - b).pop()}`;
}

console.log(solveDec(5, -3, 16, 18));
console.log(solveDec(-3, -5, -22.5, 0));

function solveMathMax(...params) {
    return `'The largest number is ${Math.max(...params)}`;
}

console.log(solveMathMax(5, -3, 16, 18));
console.log(solveMathMax(-3, -5, -22.5, 0));