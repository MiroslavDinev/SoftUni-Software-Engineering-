function getFibonator() {
    let firstElement = 0;
    let currentElement = 1;

    return function () {
        let result = firstElement + currentElement;
        firstElement = currentElement;
        currentElement = result;

        return firstElement;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13