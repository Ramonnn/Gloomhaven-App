using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierDrawCard : MonoBehaviour
{
    public Sprite[] modifierImages;
    private Image modifier, shuffleIcon;
    public GameObject disAdvantage;
    public List<ModifierCard> standardModifierDeck = new List<ModifierCard>();
    public List<ModifierCard> discardPile = new List<ModifierCard>();
    private ModifierCard currentCard;
    public bool sendShuffleMessage, drawTwo;
    private int topDeck;
    private Text monsterM;

    void Start()
    {
        standardModifierDeck = GetComponent<ModifierDeck>().standardModifierDeck;
        modifier = gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>();
        shuffleIcon = gameObject.transform.parent.transform.GetChild(1).transform.GetChild(1).transform.GetComponent<Image>();
        monsterM = gameObject.transform.parent.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Text>();
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        DrawModifier();
    }

    public void TestDraw()
    {
        modifier.sprite = gameObject.GetComponent<Image>().sprite;
        monsterM.enabled = false;
        disAdvantage.SetActive(false);
        disAdvantage.transform.GetChild(1).transform.gameObject.GetComponent<Image>().enabled = false;
        shuffleIcon.enabled = false;
        StartCoroutine(Wait());
    }

    public void DrawModifier()
    {


        topDeck = Random.Range(0, standardModifierDeck.Count);
        currentCard = standardModifierDeck[topDeck];
        
        for (int i = 0; i < modifierImages.Length; i++)
        {
            if (modifierImages[i].name == currentCard.cardModifier)
            {
                modifier.sprite = modifierImages[i];
            }
        }
        monsterM.enabled = true;
        standardModifierDeck.RemoveAt(topDeck);
        Debug.Log("Deck contains " + standardModifierDeck.Count + " Cards");
        discardPile.Add(currentCard);

        if (currentCard.shuffleDeck)
        {
            shuffleIcon.enabled = true;
            sendShuffleMessage = true;
        }

        if (standardModifierDeck.Count == 0)
        {
            Shuffle();
        }

        if (drawTwo == true) //advantage / disadvantage !! Use drawTwo on Strengthend, Muddled!
        {
            drawTwo = false;
            disAdvantage.SetActive(true);
            topDeck = Random.Range(0, standardModifierDeck.Count);
            currentCard = standardModifierDeck[topDeck];

            for (int i = 0; i < modifierImages.Length; i++)
            {
                if (modifierImages[i].name == currentCard.cardModifier)
                {
                    disAdvantage.transform.GetChild(0).GetComponent<Image>().sprite = modifierImages[i];
                }
            }

            standardModifierDeck.RemoveAt(topDeck);
            Debug.Log("Deck contains " + standardModifierDeck.Count + " Cards");
            discardPile.Add(currentCard);

            if (currentCard.shuffleDeck)
            {
                disAdvantage.transform.GetChild(1).transform.gameObject.GetComponent<Image>().enabled = true;
                sendShuffleMessage = true;
            }

            if (standardModifierDeck.Count == 0)
            {
                Shuffle();
            }
        }

    }

    public void Shuffle()
    {
        if (sendShuffleMessage)
        {
            for (int i = 0; i < discardPile.Count; i++)
            {
                standardModifierDeck.Add(discardPile[i]);
            }
            discardPile.Clear();
            sendShuffleMessage = false;
        }
    }
}
