using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TestModifierDeck : MonoBehaviour {

    public List<ModifierCard> availableModifierCards = new List<ModifierCard>();
    public List<ModifierCard> standardModifierDeck = new List<ModifierCard>();

    private void Awake()
    {
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Plus2", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Minus2", rollMod = false, oneTime = false, shuffleDeck = false });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Null", rollMod = false, oneTime = false, shuffleDeck = true });
        standardModifierDeck.Add(new ModifierCard { cardModifier = "Double", rollMod = false, oneTime = false, shuffleDeck = true });

    }

    void Start()
    {

        //available cards

        availableModifierCards.Add(new ModifierCard { cardModifier = "Bless", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Curse", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Plus0", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Plus1", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Plus2", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Minus1", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Minus2", rollMod = false, oneTime = false, shuffleDeck = false });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Null", rollMod = false, oneTime = false, shuffleDeck = true });
        availableModifierCards.Add(new ModifierCard { cardModifier = "Double", rollMod = false, oneTime = false, shuffleDeck = true });
    }
}
