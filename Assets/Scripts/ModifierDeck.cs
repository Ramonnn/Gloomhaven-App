using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierDeck : MonoBehaviour {

    public List<ModifierCard> availableModifierCards = new List<ModifierCard>();
    public List<ModifierCard> standardModifierDeck = new List<ModifierCard>();

    private void Awake()
    {
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus0", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus1", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Plus2", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Minus2", false, false, false));
        standardModifierDeck.Add(new ModifierCard("Null", false, false, true));
        standardModifierDeck.Add(new ModifierCard("Double", false, false, true));
        
    }

    void Start () {

        //available cards

        availableModifierCards.Add(new ModifierCard("Bless", false, false, false));
        availableModifierCards.Add(new ModifierCard("Curse", false, false, false));
        availableModifierCards.Add(new ModifierCard("Plus0", false, false, false));
        availableModifierCards.Add(new ModifierCard("Plus1", false, false, false));
        availableModifierCards.Add(new ModifierCard("Plus2", false, false, false));
        availableModifierCards.Add(new ModifierCard("Minus1", false, false, false));
        availableModifierCards.Add(new ModifierCard("Minus2", false, false, false));
        availableModifierCards.Add(new ModifierCard("Null", false, false, true));
        availableModifierCards.Add(new ModifierCard("Double", false, false, true));

        //standard monster deck

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
