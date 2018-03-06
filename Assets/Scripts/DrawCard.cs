using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DrawCard : MonoBehaviour
{

    public Sprite cardFront, cardBack;
    private SpriteRenderer cardArt, shuffleIcon;
    private Card currentCard;
    public TextMeshPro initiative, monsterName, line1;
    private List<Card> cardDeck = new List<Card>();
    private List<Card> discardPile = new List<Card>();
    private string objectName;

    private void Start()
    {
        objectName = gameObject.name; //GetInstanceID() could work too?
        cardDeck = GetComponentInParent<DeckCollection>().decklist[objectName];
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

    public void OnMouseDown()
    {

        if (cardArt.sprite.Equals(cardBack))
        {
            int topDeck = Random.Range(0, cardDeck.Count);
            currentCard = cardDeck[topDeck];
            cardArt.sprite = cardFront;

            monsterName.text = objectName;
            initiative.text = currentCard.initiative;
            line1.text = currentCard.ln1;

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
