﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossAbilityDeckHandler : MonoBehaviour
{
    public TextMeshProUGUI initiative, monsterName, modifierLines;
    public Image shuffleBool, cardBackground;

    public List<TestDeck> abilityDeck, discardPile;
    public TestDeck currentCard;
    public Sprite cardFront, cardBack;

    void OnEnable()
    {
        RoundTracker.UpdateInitiativeOrder += TestAbilityCardDraw;
    }

    void OnDisable()
    {
        RoundTracker.UpdateInitiativeOrder -= TestAbilityCardDraw;
    }

    private void Start()
    {
        abilityDeck = gameObject.transform.parent.parent.GetComponent<TestBossFrame>().abilityDeck;
    }

    public void TestAbilityCardDraw()
    {
        modifierLines.text = "";
        shuffleBool.enabled = false;
        int topDeck = Random.Range(0, abilityDeck.Count);
        currentCard = abilityDeck[topDeck];
        cardBackground.sprite = cardFront;
        initiative.text = currentCard.initiativeValue;
        monsterName.text = currentCard.monsterName;
        for (int i = 0; i < currentCard.modifierLines.Count; i++)
        {
            modifierLines.text = modifierLines.text + currentCard.modifierLines[i] + "\n";
        }

        abilityDeck.RemoveAt(topDeck);
        Debug.Log("Deck contains " + abilityDeck.Count + " Cards");
        discardPile.Add(currentCard);

        if (currentCard.shuffleBool)
        {
            shuffleBool.enabled = true;
            Shuffle();
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < discardPile.Count; i++)
        {
            abilityDeck.Add(discardPile[i]);
        }

        discardPile.Clear();
    }
}
