using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestCurrentBosses
{
    public string monsterName, monsterNotes;
    public List<string> monsterImmunities, Special1, Special2;
    public int monsterMove, monsterAttack, monsterRange, monsterLevel, monsterHealth;
    public Sprite monsterImage;
    public List<TestDeck> cardDeck;
}
