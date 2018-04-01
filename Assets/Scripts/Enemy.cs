using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public string enemyType;
    public Text healthInfo;
    public GameObject[] conditions;
    public GameObject[] sufferingConditions;
    public Toggle currentTurn;
    public int maxHealth;
    public int currentHealth;
    public bool dead;

    public LoadMonsterData monsterData;

    private void Start()
    {
        enemyName = gameObject.transform.name;
        enemyType = gameObject.transform.parent.name;
        if (enemyType == "Elite")
        {
            int.TryParse(monsterData.genericStatsElite[0], out maxHealth);
        }
        else if (enemyType == "Normal")
        {
            int.TryParse(monsterData.genericStatsNormal[0], out maxHealth);
        }
        maxHealth = 0; // tbc
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

}
