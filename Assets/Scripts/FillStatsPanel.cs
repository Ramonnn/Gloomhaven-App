using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatsPanel : MonoBehaviour
{

    private LoadMonsterData monsterData;
    public Sprite currentMonsterImage;

    void Start()
    {
        GetStats();
    }

    private void GetStats()
    {
        monsterData = GetComponentInParent<LoadMonsterData>();
        currentMonsterImage = monsterData.currentMonsterImage;
        transform.GetChild(4).GetComponentInChildren<Text>().text = monsterData.genericStatsNormal[0] + "\n" + monsterData.genericStatsNormal[1] + "\n" + monsterData.genericStatsNormal[2] + "\n" + monsterData.genericStatsNormal[3];
        transform.GetChild(5).GetComponentInChildren<Text>().text = monsterData.genericStatsElite[0] + "\n" + monsterData.genericStatsElite[1] + "\n" + monsterData.genericStatsElite[2] + "\n" + monsterData.genericStatsElite[3];
        transform.GetChild(1).GetComponent<Image>().sprite = currentMonsterImage;
    }
}
