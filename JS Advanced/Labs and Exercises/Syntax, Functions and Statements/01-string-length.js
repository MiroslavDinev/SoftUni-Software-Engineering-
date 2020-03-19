function solve(a, b, c) {
    let sum = a.length + b.length + c.length;
    let avrg = Math.floor(sum / 3);
    console.log(sum);
    console.log(avrg);
}

solve("chocolate", "ice cream", "cake");

function solveDec(...params) {
    let sum = params.reduce(
        (a, b) => a + b.length,
        0
    );
    let avrg = Math.floor(sum / params.length);
    console.log(sum);
    console.log(avrg);
}

solveDec("chocolate", "ice cream", "cake", "asd", "123asd");