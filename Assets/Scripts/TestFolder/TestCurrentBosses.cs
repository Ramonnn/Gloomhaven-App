using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCurrentBosses {

    public string monsterName, monsterHealth, monsterNotes, Special1, Special2;
    public int monsterMove, monsterAttack, monsterRange, monsterLevel;
    public Sprite monsterImage;
    public List<TestDeck> cardDeck;

    public TestCurrentBosses(string name, Sprite image, int level, string health, int move, int attack, int range, string special1, string special2, string notes, List<TestDeck> deck)
    {
        monsterName = name;
        monsterImage = image;
        monsterLevel = level;
        monsterHealth = health;
        monsterMove = move;
        monsterAttack = attack;
        monsterRange = range;
        Special1 = special1;
        Special2 = special2;
        monsterNotes = notes;
        cardDeck = deck;
    }
}
