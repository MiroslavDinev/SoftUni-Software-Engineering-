function solve(arr) {
    let result = [];
    arr.forEach(element => {
        if (element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    });

    result.forEach(element => {
        console.log(element);
    });
}

solve([3, -2, 0, -1]);