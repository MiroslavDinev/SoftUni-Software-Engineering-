function solve(x, y) {
    while (y) {
        let temp = y;
        y = x % y;
        x = temp;
    }

    console.log(x);
}

solve(2154, 458);