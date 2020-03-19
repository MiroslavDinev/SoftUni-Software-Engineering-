function printDeckOfCards(cards) {

    let allCards = [];

    for (let i = 0; i < cards.length; i++) {
        let currCard = cards[i];
        let suit = currCard.slice(-1);
        let face = currCard.slice(0, currCard.length - 1);

        try {
            let card = createCard(face, suit);
            allCards.push(card);
        } catch (error) {
            console.log(error.message);
        }
    }

    function createCard(face, suit) {
        const validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        const validSuits = {
            S: "\u2660",
            H: "\u2665",
            D: "\u2666",
            C: "\u2663"
        };

        if (!(validFaces.includes(face) && validSuits.hasOwnProperty(suit))) {
            throw Error(`Invalid card: ${face + suit}`);
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

    console.log(allCards.join(" "));
}