using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierCard
{
    public string cardModifier;
    public bool rollMod, oneTime, shuffleDeck;

    public ModifierCard(string modifier, bool rollmod, bool onetime, bool shuffle)
    {
        cardModifier = modifier;
        shuffleDeck = shuffle;
        rollMod = rollmod;
        oneTime = onetime;
        shuffleDeck = shuffle;
    }

}
