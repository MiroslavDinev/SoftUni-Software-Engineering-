const sum = (a, b) => a + b;
const inverseSum = (a, b) => a + 1 / b;
const stringConcat = (a, b) => a.concat(b);
const operations = [[sum, 0], [inverseSum, 0], [stringConcat, ""]];

function solve(numbers) {
    return operations.map(
        x => numbers.reduce(...x)
    );
}

console.log(
    solve([1, 2, 3]).join("\n")
);
console.log(
    solve([2, 4, 8, 16]).join("\n")
);
