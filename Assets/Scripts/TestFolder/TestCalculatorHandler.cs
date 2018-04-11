using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestCalculatorHandler : MonoBehaviour
{
    public List<GameObject> conditions = new List<GameObject>();
    public List<GameObject> activeConditions;

    public TestMonster relevantEnemy;

    public Text output;
    public GameObject calculator;
    public Toggle heal, damage;

    public void OpenCalculator(GameObject relevant)
    {
        relevantEnemy = relevant.GetComponent<TestMonster>();
        for (int i = 0; i < conditions.Count; i++)
        {
            conditions[i].transform.GetChild(0).gameObject.SetActive(false);
            if (relevantEnemy.enemyConditions[i].activeSelf)
            {
                conditions[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        gameObject.SetActive(true);
    }

    public int DamageThroughPut()
    {
        int outputInt;
        int.TryParse(output.text, out outputInt);
        return outputInt;
    }

    public List<GameObject> ConditionThroughPut() //bruteforced...
    {

        activeConditions = new List<GameObject>(relevantEnemy.activeEnemyConditions);
        foreach (GameObject condition in conditions)
        {
            if (condition.GetComponentInChildren<Toggle>().isOn)
            {
                foreach (GameObject conditionIcon in relevantEnemy.enemyConditions)
                {
                    if (conditionIcon.name == condition.name && !activeConditions.Contains(conditionIcon))
                    {
                        condition.transform.GetChild(0).gameObject.SetActive(true);
                        activeConditions.Add(conditionIcon);
                    }
                }
                condition.GetComponentInChildren<Toggle>().isOn = false;
            }
        }
        return activeConditions;
    }


    public void SubmitCalculation()
    {
        if (output.text != "")
        {
            relevantEnemy.HealthHandler(DamageThroughPut());
            output.text = "";
        }
        relevantEnemy.AddCondition(ConditionThroughPut());
        gameObject.SetActive(false);
    }
}
