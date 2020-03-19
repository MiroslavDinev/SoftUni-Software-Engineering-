function solve(num) {
    let isSame = true;
    let sum = 0;

    let numAsArr = num.toString().split("");
    let first = Number(numAsArr[0]);

    numAsArr.forEach(element => {
        sum += Number(element);

        if (Number(element) !== first) {
            isSame = false;
        }
    });

    console.log(isSame);
    console.log(sum);
}

solve(1234);