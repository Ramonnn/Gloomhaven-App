using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using System.Collections;

public class DrawCard : MonoBehaviour //Script Execution Order Adjusted +100 from default
{
    public Sprite cardFront, cardBack;
    private Image cardArt, shuffleIcon;
    private Card currentCard;
    public TextMesh initiative, monsterName, line1;
    public List<Card> cardDeck = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    public List<Combinations> monsterDeckCombi;

    private string decksFileName = "decks.json";
    public DecksList loadedDecks;

    public int intInitiative;

    private void Start()
    {
        monsterDeckCombi = GetComponentInParent<LoadScenario>().loadedMonsters.monsters;
        DeckLoader(gameObject.name);


        cardArt = gameObject.GetComponent<Image>();

        Image[] renderers = GetComponentsInChildren<Image>(); // CAN BE REFACTORED WITH transform.GetChild().GetComponent<SpriteRenderer>();

        foreach (Image renderer in renderers)
        {
            if (renderer.GetInstanceID() != GetComponent<Image>().GetInstanceID())
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

    public void RefreshDeck()
    {
        shuffleIcon.enabled = false;
        cardArt.sprite = cardBack;
        initiative.text = null;
        monsterName.text = null;
        line1.text = null;
    }

    public void DrawACard()
    {
        int topDeck = Random.Range(0, cardDeck.Count);
        currentCard = cardDeck[topDeck];
        cardArt.sprite = cardFront;

        monsterName.text = gameObject.name;
        initiative.text = currentCard.initiative;
        int.TryParse(currentCard.initiative, out intInitiative);
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


    void Shuffle()
    {
        for (int i = 0; i < discardPile.Count; i++)
        {
            cardDeck.Add(discardPile[i]);
        }

        discardPile.Clear();
    }


}
