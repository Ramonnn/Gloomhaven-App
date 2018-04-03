using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCalculatorHandler : MonoBehaviour
{
    public List<GameObject> conditions = new List<GameObject>();
    public Text output;
    public GameObject calculator;
    public Toggle heal, damage;

    public delegate void CalculatorEventHandler(string damage);

    public static event CalculatorEventHandler PassThroughDamage;

    public void PassDamage(string damage)
    {
        if (PassThroughDamage != null)
        {
            PassThroughDamage(output.text);
        }

    }

    public void CloseCalculator()
    {
        gameObject.SetActive(false);
    }
}
