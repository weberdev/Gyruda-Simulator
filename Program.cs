GameState gameState = new GameState();

card newCard = new card { name = "Flesh Duplicate", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Phantasmal Image", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Clone", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Copycrook", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Evil Twin", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Gigantoplasm", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Malleable Impostor", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Mirrorhall Mimic // Ghastly Mimicry", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Clever Impersonator", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Phyrexian Metamorph", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Sakashima of a Thousand Faces", isCopier = true, isLegendary = false };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Sakashima's Student", isCopier = true, isLegendary = false };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Sakashima the Impostor", isCopier = true, isLegendary = false };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Spark Double", isCopier = true, isLegendary = false };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Stunt Double", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Undercover Operative", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Visage Bandit", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Vizier of Many Faces", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Wall of Stolen Identity", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Auton Soldier", isCopier = true, isLegendary = true };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Callidus Assassin", isCopier = true, isLegendary = false };
gameState.AddCardToDeck(newCard);

newCard = new card { name = "Land", isCopier = false, isLegendary = false };
for (int i = 0; i < 38; i++)
{
    gameState.AddCardToDeck(newCard);
}
newCard = new card { name = "Generic Card", isCopier = false, isLegendary = false };

for (int i = 0; i <39; i++)
{
    gameState.AddCardToDeck(newCard);
}

gameState.ShuffleDeck();

for (int i = 0;i < 7; i++)
{
    gameState.drawCard();
}

for(int i = 0; i<15; i++)
{
    if (gameState.mana > 5&& gameState.turn > 5)
    {
        Console.WriteLine("Gyruda chain begins.");
        gameState.GyrudaETB();
        break;
    }
    gameState.turn++;
    gameState.drawCard();
}

public class GameState
{
    public int mana = 0;
    public int turn = 0;
    public Stack<card> Deck = new Stack<card>();
    public List<card> Hand = new List<card>();

    // Method to add a card to the deck
    public void AddCardToDeck(card newCard)
    {
        Deck.Push(newCard);
    }
    public void drawCard()
    {
        card newCard = Deck.Pop();
        Console.WriteLine(newCard.name);
        Hand.Add(newCard);
        if(newCard.name == "Land")
        {
            mana++;
        }
    }
    public void ShuffleDeck()
    {
        var list = new List<card>(Deck);
        var rng = new Random();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int k = rng.Next(i + 1);
            var value = list[k];
            list[k] = list[i];
            list[i] = value;
        }

        Deck = new Stack<card>(list);
    }
    public void GyrudaETB()
    {
        Queue<card> topFour = new Queue<card>();

        // Ensure there are at least four cards in the deck
        int numberOfCardsToPop = Math.Min(4, Deck.Count);
        for (int i = 0; i < numberOfCardsToPop; i++)
        {
            topFour.Enqueue(Deck.Pop());
        }
        bool hasCopier = false;
        foreach (card c in topFour)
        {
            Console.WriteLine(c.name);
            if (c.isCopier == true) { hasCopier = true;}
        }
        if (hasCopier == true)
        {
            Console.WriteLine("");
            GyrudaETB();
        }
        else
        {
            Console.WriteLine("Gyruda chain has ended.");
            int cardsMilled = 99 - Deck.Count;
            Console.WriteLine("Cards milled: " + cardsMilled +".");
        }
    }
}

public class card
{
    public string name;
    public bool isCopier;
    public bool isLegendary;
}

