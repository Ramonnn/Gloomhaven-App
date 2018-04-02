using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonster : MonoBehaviour
{
    public TestCurrentMonsters currentMonster;
    public Text enemyNumber, healthText;
    public List<GameObject> conditions = new List<GameObject>();
    public Toggle currentTurn;
    public Image[] shieldValues;

}
