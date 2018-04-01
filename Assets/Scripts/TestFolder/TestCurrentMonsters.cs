using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCurrentMonsters {

    public string monsterName, enemyType;
    public int monsterHealth, monsterMove, monsterAttack, monsterRange, monsterLevel;
    public List<string> attributes;
    public Sprite monsterImage;
    public List<TestDeck> cardDeck;

    public TestCurrentMonsters(string name, Sprite image, string type, int level, int health, int move, int attack, int range, List<string> attris, List<TestDeck> deck)
    {
        monsterName = name;
        monsterImage = image;
        enemyType = type;
        monsterLevel = level;
        monsterHealth = health;
        monsterMove = move;
        monsterAttack = attack;
        monsterRange = range;
        attributes = attris;
        cardDeck = deck;
    }
}
