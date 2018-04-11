using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestActiveBoss : MonoBehaviour {

    public Toggle bossToggle;
    public GameObject boss;
    public TestMonsterPanel monsterPanel;

    private void OnEnable()
    {
        TestBoss.Reset += UpdateToggles;
    }
    private void OnDisable()
    {
        TestBoss.Reset += UpdateToggles;
    }

    public void SpawnBoss()
    {
        if (bossToggle.isOn)
        {
            monsterPanel.activeMonsters.Add(boss);
            boss.SetActive(true);
        }
        else
        {
            monsterPanel.activeMonsters.Remove(boss);
            boss.SetActive(false);
        }
        monsterPanel.activeMonsters.Sort((p1, p2) => p1.name.CompareTo(p2.name));
    }

    public void UpdateToggles()
    {
        if (!boss.activeSelf)
        {
            bossToggle.isOn = false;
        }
    }
}
