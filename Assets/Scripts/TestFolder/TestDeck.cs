using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeck
{
    public string monsterName, initiativeValue;
    public bool shuffleBool;
    public List<string> modifierLines;

    public TestDeck(string name, string initiative, bool shuffle, List<string> cardlines)
    {
        monsterName = name;
        initiativeValue = initiative;
        shuffleBool = shuffle;
        modifierLines = cardlines;
    }
}
