(function () {
    const validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    const suits = {
        SPADES: "\u2660",
        HEARTS: "\u2665",
        DIAMONDS: "\u2666",
        CLUBS: "\u2663"
    };

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }
        set face(face) {
            if (!validFaces.includes(face)) {
                throw new Error ("Invalid face!");
            }
            this._face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(suit) {
            if (!Object.values(suits).some(s=> s===suit)) {
                throw new Error ("Invalid suit!");
            }

            this._suit = suit;
        }
    }

    return {
        Suits: suits,
        Card: Card
    };
}());