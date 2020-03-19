function solve(text) {
    return text.match(/\w+/gim)
        .map(x => x.toUpperCase());
}

console.log(solve("Hi, how are you?").join(", "));
console.log(solve("hello").join(", "));