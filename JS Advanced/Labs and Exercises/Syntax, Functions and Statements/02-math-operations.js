function solve(x, y, operator) {
    let result;
    switch (operator) {
        case "+": result = x + y;
            break;
        case "-": result = x - y;
            break;
        case "/": result = x / y;
            break;
        case "*": result = x * y;
            break;
        case "%": result = x % y;
            break;
        case "**": result = x ** y;
            break;
    }

    return result;
}

console.log(
    solve(5, 6, "+")
);

const add = (x, y) => x + y;
const substract = (x, y) => x - y;
const divide = (x, y) => x / y;
const multiply = (x, y) => x * y;
const mod = (x, y) => x % y;
const expo = (x, y) => x ** y;

const operationsMap = {
    "+": add,
    "-": substract,
    "/": divide,
    "*": multiply,
    "%": mod,
    "**": expo,
}

function solveDec(operator, ...params) {
    return params.reduce(
        (a, b) => operationsMap[operator](a, b),
        params.shift()
    );
}

console.log(
    solveDec("+", 2, 1),
    solveDec("-", 2, 1),
    solveDec("*", 1, 2),
    solveDec("/", 2, 2),
    solveDec("%", 4, 2),
    solveDec("**", 2, 3)
);
