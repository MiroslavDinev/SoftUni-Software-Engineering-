function solve(arr) {
    let number = 1;
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === "remove") {
            result.pop();
        } else {
            result.push(number);
        }
        number++;
    }

    console.log(result.length === 0 ? "Empty" : result.join("\n"));
}

solve(['remove', 
'remove', 
'remove']
);