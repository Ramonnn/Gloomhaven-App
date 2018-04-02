using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAddMonsterPopUp : MonoBehaviour
{

    public List<GameObject> popUpMonsters = new List<GameObject>();
    public GameObject addMonsterPopUp;

    public void MonsterPopUp()
    {
        Debug.Log("Click");
        if (addMonsterPopUp.activeSelf)
        {
            addMonsterPopUp.SetActive(false);
        }
        else
        {
            addMonsterPopUp.SetActive(true);
        }
    }

    public void AddMonsters()
    {
        foreach (GameObject enemy in popUpMonsters)
        {
            if (enemy.GetComponent<TestActiveEnemy>().normalToggle.isOn)
            {
                enemy.GetComponent<TestActiveEnemy>().normal.SetActive(true);
                enemy.GetComponent<TestActiveEnemy>().elite.SetActive(false);
            }
            else if (enemy.GetComponent<TestActiveEnemy>().eliteToggle.isOn)
            {
                enemy.GetComponent<TestActiveEnemy>().elite.SetActive(true);
                enemy.GetComponent<TestActiveEnemy>().normal.SetActive(false);
            }
            else
            {
                enemy.GetComponent<TestActiveEnemy>().elite.SetActive(false);
                enemy.GetComponent<TestActiveEnemy>().normal.SetActive(false);
            }
        }
    }
}
