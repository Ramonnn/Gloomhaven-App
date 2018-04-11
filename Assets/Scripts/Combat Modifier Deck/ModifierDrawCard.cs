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
    public ModifierCard curse, bless, stockCard;
    private ModifierCard currentCard;
    public GameObject modifierDeck, blessModifier, curseModifier;
    public bool sendShuffleMessage, drawTwo;
    private int topDeck;
    private Text monsterM;

    [System.Serializable]
    public struct ModifierCard
    {
        public string cardModifier;
        public bool rollMod, shuffleDeck;

    }
    public List<ModifierCard> basicModifierDeck = new List<ModifierCard>() {
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus2", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus2", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Null", rollMod = false, shuffleDeck = true},
        new ModifierCard { cardModifier = "Double", rollMod = false, shuffleDeck = true } };

    public List<ModifierCard> availableModifierCards = new List<ModifierCard>() {
        new ModifierCard { cardModifier = "Bless", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Curse", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus0", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Plus2", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus1", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Minus2", rollMod = false, shuffleDeck = false },
        new ModifierCard { cardModifier = "Null", rollMod = false, shuffleDeck = true },
        new ModifierCard { cardModifier = "Double", rollMod = false, shuffleDeck = true } };


void Start()
    {
        standardModifierDeck = basicModifierDeck;
        curse = availableModifierCards[1];
        bless = availableModifierCards[0];
        modifier = modifierDeck.transform.GetChild(0).GetComponent<Image>();
        shuffleIcon = modifierDeck.transform.GetChild(1).GetComponent<Image>();
        monsterM = modifierDeck.transform.GetChild(2).GetComponent<Text>();
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
        if (currentCard.cardModifier == "Bless")
        {
            blessModifier.SetActive(false);
        }
        if (currentCard.cardModifier == "Curse")
        {
            curseModifier.SetActive(false);
        }
        else
        {
            discardPile.Add(currentCard);
        }

        if (currentCard.shuffleDeck)
        {
            shuffleIcon.enabled = true;
            sendShuffleMessage = true;
        }

        if (standardModifierDeck.Count == 0)
        {
            Shuffle();
        }

        if (drawTwo == true)
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
            if (currentCard.cardModifier == "Bless")
            {
                blessModifier.SetActive(false);
            }
            if (currentCard.cardModifier == "Curse")
            {
                curseModifier.SetActive(false);
            }
            else
            {
                discardPile.Add(currentCard);
            }

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

    void OnEnable()
    {
        RoundTracker.TrackingRound += Shuffle;
    }

    void OnDisable()
    {
        RoundTracker.TrackingRound -= Shuffle;
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
