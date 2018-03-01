using UnityEngine;
using System.Collections.Generic;


public class DeckCollection : MonoBehaviour {

    public static List<Card> ancientArtillery = new List<Card>()
        {
            new Card("46", false, "attack -1", "range +2"),
            new Card("71", true, "attack +0", "range +0", "All adjacent enemies suffer 2 damage"),
            new Card("71", true, "attack +0", "range +0", "All adjacent enemies suffer 2 damage"),
            new Card("37", false, "push 1", "Target all adjacent enemies", "attack -1 aoe-triangle-2-side", "range -1"),
            new Card("37", false, "push 1", "Target all adjacent enemies", "attack -1 aoe-circle", "range -1"),
            new Card("37", false, "push 2", "Target all adjacent enemies", "shield 2", "attack -2", "range -1"),
            new Card("95", false, "attack +1", "range +0"),
            new Card("46", false, "attack -1", "aoe-triangle-2-side", "range +0", "immobilize")
        };

    public static List<Card> archer = new List<Card>()
        {
            new Card("16", false, "move +1", "attack -1", "range +0"),
            new Card("31", false, "move +0", "attack +0", "range +0"),
            new Card("32", false, "move +0", "attack +1", "range -1"),
            new Card("44", false, "move -1", "attack +1", "range +0"),
            new Card("56", false, "attack -1", "range +0", "target 2"),
            new Card("68", true, "attack +1", "range +1"),
            new Card("14", false, "move -1", "attack -1", "range +0", "Create a 3 damage trap in an adjacent empty hex closest to an enemy"),
            new Card("29", true, "move +0", "attack -1", "range +1", "immobilize")
        };




    public static Dictionary<string, List<Card>> decklist = new Dictionary<string, List<Card>>();

    private void Start()
    {

    decklist.Add("Ancient Artillery", ancientArtillery);
    decklist.Add("Bandit Archer", archer);
    decklist.Add("City Archer", archer);
    decklist.Add("Inox Archer", archer);

    }

    public List<Card> discardPile = new List<Card>();

}
