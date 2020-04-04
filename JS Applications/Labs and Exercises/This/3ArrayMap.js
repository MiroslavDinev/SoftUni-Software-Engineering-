function arrayMap(arr, fn) {
    let result = new Array(arr.length);

    for (let i = 0; i < arr.length; i++) {
        result[i] = fn(arr[i]);
    }

    return result;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2));

let letters = ["a", "b", "c"];
console.log(arrayMap(letters, (l) => l.toLocaleUpperCase()));