// JavaScript source code
class Card {
    constructor(name, isCopier = false, isLegendary = false, isRelevant = false) {
        this.name = name;
        this.isCopier = isCopier;
        this.isLegendary = isLegendary;
        this.isRelevant = isRelevant;
    }
}

type Deck = CardType[]
