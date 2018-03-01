using System.Collections.Generic;

public class Deck
{
    public string name;
    public List<Card> deck;

    public Deck(string monsterName, List<Card> cardDeck)
    {
        name = monsterName;
        deck = cardDeck;
    }

}
