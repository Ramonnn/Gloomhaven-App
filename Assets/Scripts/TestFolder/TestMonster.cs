using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonster : MonoBehaviour
{
    public TestCurrentMonsters currentMonster;
    public GameObject calculator;
    public Text healthText;
    public List<GameObject> conditions = new List<GameObject>();
    public Toggle currentTurn;
    public Image[] shieldValues;


    private void OnEnable()
    {
        AssignStartValues();
        //Event listener can go here (if something applies to all monsters that are active)
    }

    private void AssignStartValues()
    {
        healthText.text = currentMonster.monsterHealth.ToString() + "/" + currentMonster.monsterHealth.ToString();
        //if monsters starts with anything else than specific health, insert here.
    }

    public void OpenCalculator()
    {
        TestCalculatorHandler.PassThroughDamage += HealthHandler;
        calculator.SetActive(true);
    }

    private void HealthHandler(string damage)
    {
        TestCalculatorHandler.PassThroughDamage -= HealthHandler;
        if (calculator.GetComponent<TestCalculatorHandler>().damage.isOn)
        {
            //parse to int.
        }
        else if (calculator.GetComponent<TestCalculatorHandler>().heal.isOn)
        {
            //parse to int.
        }
        else
        {
            //aoe damage.
        }

    }

    public void CurrentTurn()
    {
        if (currentTurn)
        {
            ConditionHandler();
        }
    }

    private void ConditionHandler()
    {
        foreach (GameObject condition in conditions)
        {
            if (condition.activeSelf)
            {
                switch (condition.name)
                {
                    case "Poisoned":
                        //damageTaken = damageTaken +1;
                        break;
                    case "Wounded":
                        //remainingHealth = remainingHealth -1;
                        break;
                    case "Dazed":
                        //health = health -1;
                        //Remove Dazed
                        break;
                    case "Muddled":
                        //DisAdvantage = true;
                        //Remove Muddled
                        break;
                    case "Crippled":
                        //health = health -1;
                        //Remove Crippled
                        break;
                    case "Disarmed":
                        //currentTurn = false;
                        //Remove Disarmed
                        break;
                    case "Cursed":
                        //modifierDeck.Add(CursedCard);
                        //Remove Cursed
                        break;
                    case "Blessed":
                        //modifierDeck.Add(BlessedCard);
                        //Remove Blessed
                        break;
                    case "Strengthend":
                        //DisAdvantage = true;
                        //Remove Strengthend
                        break;
                    case "Invisible":
                        //Remove Invisible
                        break;
                }
            }
        }
    }
}
