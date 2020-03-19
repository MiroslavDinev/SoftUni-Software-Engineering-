function solve(matrix) {
    let isMagic = true;
    let sum = matrix[0].reduce((a, b) => a + b);
    for (let i = 0; i < matrix.length; i++) {
        let rowSum = matrix[i].reduce((a, b) => a + b);
        let colSum = matrix.map((x) => x[i]).reduce((a, b) => a + b);
        if (sum !== rowSum || sum !== colSum || colSum !== rowSum) {
            isMagic = false;
        }
    }
    console.log(isMagic);
}

solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   );