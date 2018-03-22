using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalHandler : MonoBehaviour
{

    private LoadMonsterData monsterData;

    void Start()
    {
        GetNormalStats();
    }

    private void GetNormalStats()
    {
        monsterData = GetComponentInParent<LoadMonsterData>();
        foreach (Transform normal in gameObject.transform)
        {
            normal.transform.GetChild(1).GetComponent<Text>().text = monsterData.genericStatsNormal[0] + "/" + monsterData.genericStatsNormal[0]; //health
        }
    }
}
