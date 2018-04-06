using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAddMonsterPopUp : MonoBehaviour
{
    public List<GameObject> popUpMonsters = new List<GameObject>();
    public TestMonsterPanel monsterPanel;
    public GameObject addMonsterPopUp;

    public void MonsterPopUp()
    {
        if (addMonsterPopUp.activeSelf)
        {
            addMonsterPopUp.SetActive(false);
        }
        else
        {
            addMonsterPopUp.SetActive(true);
        }
    }
}
