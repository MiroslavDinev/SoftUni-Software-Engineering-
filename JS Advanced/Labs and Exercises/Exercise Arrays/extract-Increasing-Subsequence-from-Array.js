function solve(arr) {
    let result = [];
    let currBiggest = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < arr.length; i++) {
        let currNum = arr[i];
        if (currNum >= currBiggest) {
            result.push(currNum);
            currBiggest = currNum;
        }
    }
    console.log(result.join("\n"));
}

solve([20,
    3,
    2,
    15,
    6,
    1
]);