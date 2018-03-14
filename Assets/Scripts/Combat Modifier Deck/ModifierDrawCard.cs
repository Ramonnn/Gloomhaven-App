using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierDrawCard : MonoBehaviour
{

    public Sprite cardFront, cardBack;
    public Sprite[] modifierImages;
    private SpriteRenderer cardArt, shuffleIcon;
    private GameObject discardPileArt, shuffleIconArt;
    public List<ModifierCard> standardModifierDeck = new List<ModifierCard>();
    public List<ModifierCard> discardPile = new List<ModifierCard>();
    private ModifierCard currentCard;

    void Start()
    {
        ModifierDeckLoader();
        discardPileArt = GameObject.Find("MainModifier");
        cardArt = discardPileArt.GetComponent<SpriteRenderer>();
        shuffleIconArt = GameObject.Find("ShuffleBool");
        shuffleIcon = shuffleIconArt.GetComponent<SpriteRenderer>();
    }

    public void ModifierDeckLoader()
    {
        standardModifierDeck = GetComponent<ModifierDeck>().standardModifierDeck;
    }

    public void OnMouseDown()
    {
        shuffleIcon.enabled = false;
        int topDeck = Random.Range(0, standardModifierDeck.Count);
        currentCard = standardModifierDeck[topDeck];

        for (int i = 0; i < modifierImages.Length; i++)
        {
            if (modifierImages[i].name == currentCard.cardModifier)
            {
                cardArt.sprite = modifierImages[i];
            }
        }

        standardModifierDeck.RemoveAt(topDeck);
        Debug.Log("Deck contains " + standardModifierDeck.Count + " Cards");
        discardPile.Add(currentCard);

        if (currentCard.shuffleDeck)
        {
            shuffleIcon.enabled = true;
            Shuffle();
        }

    }

    void Shuffle()
    {
        for (int i = 0; i < discardPile.Count; i++)
        {
            standardModifierDeck.Add(discardPile[i]);
        }
        discardPile.Clear();
    }
}
