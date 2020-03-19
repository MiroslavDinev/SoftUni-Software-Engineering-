function subSum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr)) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex > arr.length - 1) {
        endIndex = arr.length - 1;
    }

    for (let i = 0; i < arr.length; i++) {
        let element = arr[i];
        if (typeof element !== "number") {
            return NaN;
        }
    }

    let subArr = arr.slice(startIndex, endIndex + 1);

    if (subArr.length > 0) {
        return subArr.reduce((a, b) => a + b);
    } else {
        return 0;
    }
}

console.log(
    subSum('text', 0, 2)
);