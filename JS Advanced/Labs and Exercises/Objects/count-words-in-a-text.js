function solve(arr) {
    let result = {};

    let sentence = arr[0].match(/\w+/g);

    for (let word of sentence) {
        if (!result.hasOwnProperty(word)) {
            result[word] = 0;
        }
        result[word]++;
    }

    result = JSON.stringify(result);
    console.log(result);
}

solve(['Far too slow, you\'re far too slow.']);