using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestBossFrame: MonoBehaviour
{
    public GameObject genericDeck, monsterPopUp, monsterPanel;
    public List<TestDeck> abilityDeck;
    public Text monsterName;
    public Image monsterImage;
    public Button nextEnemy;
    public TextMeshProUGUI special1Boss, special2Boss, immunities, notes;
    public Text staticBoss;
}

