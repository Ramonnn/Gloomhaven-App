using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;


public class DrawCard : MonoBehaviour
{
    public Sprite cardFront, cardBack;
    private SpriteRenderer cardArt, shuffleIcon;
    private Card currentCard;
    public TextMesh initiative, monsterName, line1;
    public List<Card> cardDeck = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    public List<Combinations> monsterDeckCombi;

    private string decksFileName = "decks.json";
    public DecksList loadedDecks;

    public string monsters, bosses;
    private JSONNode MONSTERSTATS;
    public string selectedLevel;
    private string monsterStatsFileName = "monsterstats.json";

    public Sprite[] monsterImages;
    public Sprite currentMonsterImage;

    private void Start()
    {
        monsterDeckCombi = GetComponentInParent<LoadScenario>().loadedMonsters.monsters;
        DeckLoader(gameObject.name);
        LoadMonsterData(gameObject.name);


        cardArt = gameObject.GetComponent<SpriteRenderer>();

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.GetInstanceID() != GetComponent<SpriteRenderer>().GetInstanceID())
            {
                shuffleIcon = renderer;
            }
        }
    }

    public void DeckLoader(string monstername)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, decksFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedDecks = JsonUtility.FromJson<DecksList>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Deck data!");
        }
        for (int i = 0; i < monsterDeckCombi.Count; i++)
        {
            if (monstername == monsterDeckCombi[i].name)
            {
                Debug.Log("Loading contents for " + monsterDeckCombi[i].name);
                string getMonsterClass = monsterDeckCombi[i].monsterclass;
                for (int x = 0; x < loadedDecks.decks.Count; x++)
                {
                    if (getMonsterClass == loadedDecks.decks[x].monsterclass)
                    {
                        cardDeck = loadedDecks.decks[x].cards;
                    }

                }
            }
        }
    }

    private void LoadMonsterData(string monstername) // Merge with JSONNODE?
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            MONSTERSTATS = JSON.Parse(dataAsJson);

            //Debug.Log(test["monsters"]["Ancient Artillery"]["level"][1]["normal"]["health"]); // Deepest branch reference example.
            int monsterHealth = GetMonsterfromJSON(monstername, 1, "normal")["health"]; //level and monstertype will eventually be defined by the player.
            int monsterMove = GetMonsterfromJSON(monstername, 1, "normal")["move"];
            int monsterAttack = GetMonsterfromJSON(monstername, 1, "normal")["attack"];
            int monsterRange = GetMonsterfromJSON(monstername, 1, "normal")["range"];
            List<string> monsterAttri = new List<string>();
            for (int i = 0; i < GetMonsterfromJSON(monstername, 1, "normal")["attributes"].Count; i++)
            {
             monsterAttri.Add(GetMonsterfromJSON(monstername, 1, "normal")["attributes"][i].ToString());
            }

            foreach (Sprite image in monsterImages)
            {
                if (image.name == "Horz-" + gameObject.name)
                {
                    Debug.Log("found Image");
                    currentMonsterImage = image; //Image spawn in enemyframe
                }
            }
        }
        else
        {
            Debug.LogError("Cannot load MonsterStats data!");
        }
    }

    JSONNode GetMonsterfromJSON(string name, int scenarioLevel, string EliteOrNorm) // to be continued...
    {
        foreach (KeyValuePair<string, JSONNode> monster in MONSTERSTATS["monsters"])
        {
            if (monster.Key == name)
            {
                if (EliteOrNorm == "normal")
                {
                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["normal"];
                }
                else
                {
                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["elite"];
                }
            }
        }
        return null;
    }

    public void OnMouseDown()
    {

        if (cardArt.sprite.Equals(cardBack))
        {
            int topDeck = Random.Range(0, cardDeck.Count);
            currentCard = cardDeck[topDeck];
            cardArt.sprite = cardFront;

            monsterName.text = gameObject.name;
            initiative.text = currentCard.initiative;
            for (int i = 0; i < currentCard.cardlines.Count; i++)
            {
                line1.text = line1.text + currentCard.cardlines[i] + "\n";
            }

            cardDeck.RemoveAt(topDeck);
            Debug.Log("Deck contains " + cardDeck.Count + " Cards");
            discardPile.Add(currentCard);

            if (currentCard.shuffle)
            {
                shuffleIcon.enabled = true;
                Shuffle();
            }
        }
        else
        {
            shuffleIcon.enabled = false;
            cardArt.sprite = cardBack;
            initiative.text = null;
            monsterName.text = null;
            line1.text = null;

        }
    }

    void Shuffle()
    {
        for (int i = 0; i < discardPile.Count; i++)
        {
            cardDeck.Add(discardPile[i]);
        }

        discardPile.Clear();
    }


}
