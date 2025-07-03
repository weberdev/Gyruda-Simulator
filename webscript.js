// JavaScript source code
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


function addCardToDeck(card){
    this.deck.push(card)
}
function shuffleDeck(){
    for (let i = this.deck.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [this.deck[i], this.deck[j]] = [this.deck[j], this.deck[i]]
    }
}

function drawCard() {
    const card = this.deck.pop();
    console.log(card.name);
    if (card.name === "land") this.mana++;
}

gyrudaETB(){
    if (this.deck.length < 4) {
        console.log("Gyruda chain has ended, you've milled yourself, presumably everyone else as well");
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
        console.log("Cards milled: "+ cardsMilled +".")
    }
}
}