using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestActiveEnemy : MonoBehaviour {

    public Toggle normalToggle, eliteToggle;
    public GameObject normal, elite;
    public TestMonsterPanel monsterPanel;

    private void OnEnable()
    {
        TestMonster.Reset += UpdateToggles;
    }
    private void OnDisable()
    {
        TestMonster.Reset += UpdateToggles;
    }

    public void SpawnNormal()
    {
        if (normalToggle.isOn)
        {
            monsterPanel.activeMonsters.Add(normal);
            normal.SetActive(true);
        }
        else
        {
            monsterPanel.activeMonsters.Remove(normal);
            normal.SetActive(false);
        }
        monsterPanel.activeMonsters.Sort((p1, p2) => p1.name.CompareTo(p2.name));
    }

    public void SpawnElite()
    {
        if (eliteToggle.isOn)
        {
            monsterPanel.activeMonsters.Add(elite);
            elite.SetActive(true);
        }
        else
        {
            monsterPanel.activeMonsters.Remove(elite);
            elite.SetActive(false);
        }
        monsterPanel.activeMonsters.Sort((p1, p2) => p1.name.CompareTo(p2.name));
    }

    public void UpdateToggles()
    {
        if (!elite.activeSelf && !normal.activeSelf)
        {
            eliteToggle.isOn = false;
            normalToggle.isOn = false;
        }
    }
}
