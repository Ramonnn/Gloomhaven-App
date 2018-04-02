using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestCurrentMonsters
{
    public string monsterName, enemyType;
    public int monsterHealth, monsterMove, monsterAttack, monsterRange, monsterLevel;
    public List<string> attributes;
    public Sprite monsterImage;
    public List<TestDeck> cardDeck;

}
