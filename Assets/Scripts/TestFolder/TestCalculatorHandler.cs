using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestCalculatorHandler : MonoBehaviour
{
    public List<GameObject> conditions = new List<GameObject>();
    public List<GameObject> activedConditions = new List<GameObject>();

    public TestMonster relevantEnemy;

    public Text output;
    public GameObject calculator;
    public Toggle heal, damage;

    public int DamageThroughPut()
    {
        int outputInt;
        int.TryParse(output.text, out outputInt);
        return outputInt;
    }

    public List<GameObject> ConditionThroughPut()
    {
        foreach (GameObject condition in conditions)
        {
            if (condition.GetComponent<Toggle>().isOn && !activedConditions.Contains(condition))
            {
                activedConditions.Add(condition);
            }
        }
        return activedConditions;
    }


    public void SubmitCalculation()
    {
        if (output.text != "")
        {
            relevantEnemy.HealthHandler(DamageThroughPut());
            output.text = "";
        }
        if (activedConditions.Count != 0)
        {
            relevantEnemy.AddCondition(ConditionThroughPut());
        }
        gameObject.SetActive(false);
    }
}
