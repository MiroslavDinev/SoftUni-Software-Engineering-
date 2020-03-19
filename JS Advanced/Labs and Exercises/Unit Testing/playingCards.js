function solve(face, suit) {
    const validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    const validSuits = {
        S: "\u2660",
        H: "\u2665",
        D: "\u2666",
        C: "\u2663"
    };

    if (!(validFaces.includes(face) && validSuits.hasOwnProperty(suit))) {
        throw Error("Error");
    }

    var card = {
        face: face,
        suit: validSuits[suit],
        toString: function () {
            return this.face + this.suit;
        }
    };

    return card.toString();
}

console.log(
    solve('1', 'C')
);