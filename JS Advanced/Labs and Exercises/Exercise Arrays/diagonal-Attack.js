function solve(matrix) {
    let numberMatrix = [];
    for (let currArr of matrix) {
        let currArrAsNums = currArr.split(" ").map(Number);
        numberMatrix.push(currArrAsNums);
    }

    let mainDiagonal = 0;
    let secondDiagonal = 0;
    for (let row = 0; row < numberMatrix.length; row++) {
        mainDiagonal += numberMatrix[row][row];
        secondDiagonal += numberMatrix[row][numberMatrix.length - 1 - row];
    }

    if (mainDiagonal === secondDiagonal) {
        for (let row = 0; row < numberMatrix.length; row++) {
            for (let col = 0; col < numberMatrix.length; col++) {
                if (row !== col && row !== numberMatrix.length - 1 - col) {
                    numberMatrix[row][col] = mainDiagonal;
                }
            }
        }

        printMatrix(numberMatrix);
    } else {
        printMatrix(numberMatrix);
    }

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(" "));
        }
    }

}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1'
]);