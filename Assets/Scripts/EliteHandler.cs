using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliteHandler : MonoBehaviour
{

    private LoadMonsterData monsterData;
    public string maxHealth;

    void Start()
    {
        GetEliteStats();
    }

    private void GetEliteStats()
    {
        monsterData = GetComponentInParent<LoadMonsterData>();
        maxHealth = monsterData.genericStatsElite[0];
        foreach (Transform elite in gameObject.transform)
        {
            elite.transform.GetChild(1).GetComponent<Text>().text = monsterData.genericStatsElite[0] + "/" + monsterData.genericStatsElite[0]; //health
        }
    }
}
