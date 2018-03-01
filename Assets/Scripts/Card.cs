public class Card
{

    public string ln1, ln2, ln3, ln4, ln5, initiative;
    public bool shuffle;
    public int scenarioNumber;

    public Card(string initiativeNr, bool shuffleDeck, string line1 = "", string line2 = "", string line3 = "", string line4 = "", string line5 = "")
    {
        initiative = initiativeNr;
        ln1 = line1;
        ln2 = line2;
        ln3 = line3;
        ln4 = line4;
        ln5 = line5;
        shuffle = shuffleDeck;
    }

}
