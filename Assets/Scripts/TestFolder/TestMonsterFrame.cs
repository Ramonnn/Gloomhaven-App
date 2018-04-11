using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestMonsterFrame: MonoBehaviour
{
    public GameObject genericDeck, staticNormal, staticElite, monsterPopUp, monsterPanel;
    public List<TestDeck> abilityDeck;
    public Text monsterName;
    public Image monsterImage;
    public Button nextEnemy;
    public TextMeshProUGUI attributesElite, attributesNormal;
}

