function solve(arr) {
    let number = Number(arr.shift());

    let operations = {
        'chop': x => {
            return (x / 2);
        },
        'dice': x => {
            return Math.sqrt(x);
        },
        'spice': x => {
            return x += 1;
        },
        'bake': x => {
            return x *= 3;
        },
        'fillet': x => {
            return x * 0.8;
        }
    };

    arr.forEach(element => {
        number = operations[element](number);
        console.log(number);
    });
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);