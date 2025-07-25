class Card {
    constructor(name, isCopier = false, isLegendary = false, isRelevant = false) {
        this.name = name;
        this.isCopier = isCopier;
        this.isLegendary = isLegendary;
        this.isRelevant = isRelevant;
    }
}

class GameState {
    constructor() {
        this.mana = 0;
        this.turn = 0;
        this.deck = [];
    }

    addCardToDeck(card) {
        this.deck.push(card);
    }

    shuffleDeck() {
        for (let i = this.deck.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [this.deck[i], this.deck[j]] = [this.deck[j], this.deck[i]];
        }
    }

    drawCard() {
        const card = this.deck.pop();
        console.log(card.name);
        if (card.name.toLowerCase() === "land") this.mana++;
    }

    gyrudaETB() {
        if (this.deck.length < 4) {
            console.log("Gyruda chain has ended � you've milled yourself, presumably everyone else as well.");
            return;
        }
        const topFour = this.deck.splice(-4);
        let hasCopier = false;
        topFour.forEach(card => {
            console.log(card.name);
            if (card.isCopier) hasCopier = true;
        });

        if (hasCopier) {
            console.log("");
            this.gyrudaETB();
        } else {
            console.log("Gyruda chain has ended.");
            const cardsMilled = 99 - this.deck.length;
            console.log("Cards milled: " + cardsMilled + ".");
        }
    }
}

const gameState = new GameState();
//I'm not sure if I should implement a case for a plotted visage bandit'
// Clones
const cloneNames = [
    "Flesh Duplicate", "Phantasmal Image", "Clone", "Copycrook",
    "Evil Twin", "Gigantoplasm", "Malleable Impostor", "Mirrorhall Mimic",
    "Clever Impersonator", "Phyrexian Metamorph", "Sakashima's Student",
    "Spark Double", "Stunt Double", "Undercover Operative"
];

cloneNames.forEach(name => {
    gameState.addCardToDeck(new Card(name, true, false));
});

for (let i = 0; i < 38; i++) {
    gameState.addCardToDeck(new Card("Land"));
}

for (let i = 0; i < (99 - cloneNames.length - 38); i++) {
    gameState.addCardToDeck(new Card("Filler    "));
}

for (let i = 0; i < 15; i++) {
    if (gameState.mana > 5 && gameState.turn > 5) {
        console.log("Gyruda chain begins.");
        gameState.gyrudaETB();
        break;
    }
    gameState.turn++;
    gameState.drawCard();
}