using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawCard : MonoBehaviour
{
    public Sprite cardFront, cardBack;
    private SpriteRenderer cardArt, shuffleIcon;
    private Card currentCard;
    public TextMesh initiative, monsterName, line1;
    public List<Card> cardDeck = new List<Card>();
    private List<Card> discardPile = new List<Card>();
    private string objectName;
    public List<Deck> deckList;
    public List<Combinations> monsterDeckCombi;

    private void Start()
    {
        deckList = GetComponentInParent<LoadScenario>().loadedDecks.decks;
        monsterDeckCombi = GetComponentInParent<LoadScenario>().loadedMonsters.monsters;
        objectName = gameObject.name; //GetInstanceID() could work too? THIS NEEDS TO CHANGE. INDIVIDUAL CARDS MAYBE?
        DeckLoader();


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

    public void DeckLoader()
    {
        for (int i = 0; i < monsterDeckCombi.Count; i++)
        {
            if (objectName == monsterDeckCombi[i].name)
            {
                Debug.Log("Loading contents for " + monsterDeckCombi[i].name);
                string getMonsterClass = monsterDeckCombi[i].monsterclass;
                for (int x = 0; x < deckList.Count; x++)
                {
                    if (getMonsterClass == deckList[x].monsterclass)
                    {
                        cardDeck = deckList[x].cards;
                    }

                }
            }
        }
    }

    public void OnMouseDown()
    {

        if (cardArt.sprite.Equals(cardBack))
        {
            int topDeck = Random.Range(0, cardDeck.Count);
            currentCard = cardDeck[topDeck];
            cardArt.sprite = cardFront;

            monsterName.text = objectName;
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
