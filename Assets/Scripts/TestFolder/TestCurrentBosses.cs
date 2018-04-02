using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestCurrentBosses
{

    public string monsterName, monsterHealth, monsterNotes, Special1, Special2;
    public int monsterMove, monsterAttack, monsterRange, monsterLevel;
    public Sprite monsterImage;
    public List<TestDeck> cardDeck;
}
