function solve(arr) {
    let rotations = Number(arr.pop());
    for (let i = 0; i < rotations % arr.length; i++) {
        let last = arr.pop();
        arr.unshift(last);
    }

    console.log(arr.join(" "));
}

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15'
]);