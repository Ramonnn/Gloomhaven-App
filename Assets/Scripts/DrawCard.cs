using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DrawCard : MonoBehaviour //Most of this needs to move to DeckSpawner() in LoadScenario.cs. Leave only the actual random card draw and shuffle OnMousDown() here...
{

    public Sprite cardFront, cardBack;
    private SpriteRenderer frontFacing, shuffleIcon;
    private Card currentCard;
    public TextMeshPro initiative, monsterName, line1;
    public Dictionary<string, List<Card>> decklist;
    public List<Card> cardDeck;
    public DeckCollection dc;

    private void Start()
    {
        frontFacing = gameObject.GetComponent<SpriteRenderer>();
        shuffleIcon = GameObject.Find("Shuffle").GetComponent<SpriteRenderer>();
        dc = GetComponent<DeckCollection>();
        decklist = DeckCollection.decklist;
        cardDeck = DeckCollection.ancientArtillery;
    }

    public void OnMouseDown()
    {

        if (frontFacing.sprite.Equals(cardBack))
        {
            int index = Random.Range(0, cardDeck.Count);
            currentCard = cardDeck[index];
            frontFacing.sprite = cardFront;
            initiative.text = currentCard.initiative;
            //monsterName.text = decklist["Ancient Artillery"].;
            line1.text = currentCard.ln1;

            shuffleIcon.enabled = currentCard.shuffle;

            cardDeck.RemoveAt(index);
            dc.discardPile.Add(currentCard);

            if (currentCard.shuffle)
            {
                Shuffle();
            }
        }
        else
        {
            shuffleIcon.enabled = false;
            frontFacing.sprite = cardBack;
            initiative.text = null;
            monsterName.text = null;
            line1.text = null;

        }

        //Debug.Log("You have clicked the card!");
        //card.sprite = Resources.Load<Sprite>("nameSprite" + Random.Range(0, deckSize));
    }

    void Shuffle()
    {
        for (int i = 0; i < dc.discardPile.Count; i++)
        {
            cardDeck.Add(dc.discardPile[i]);
        }

        dc.discardPile.Clear();
    }


}
