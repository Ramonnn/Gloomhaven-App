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
    public List<GameObject> waningConditions = new List<GameObject>();
    public Toggle currentTurn;
    public Image[] shieldValues;
    public int remainingHealth, maxHealth, shield;
    public bool poisoned, wounded;

    private void OnEnable()
    {
        FreshEnemy();
    }

    public void PresentAsRelevant()
    {
        calculator.GetComponent<TestCalculatorHandler>().relevantEnemy = gameObject.GetComponent<TestMonster>();
    }

    public void FreshEnemy()
    {
        foreach (GameObject condition in conditions)
        {
            if (condition.activeSelf)
            {
                condition.SetActive(false);
            }
        }
        maxHealth = currentMonster.monsterHealth;
        remainingHealth = currentMonster.monsterHealth;

        healthText.text = maxHealth + "/" + maxHealth;

        //Shield Deactivate. Retaliate Deactivate.
    }

    public void OpenCalculator()
    {
        PresentAsRelevant();
        calculator.SetActive(true);
    }

    public void HealthHandler(int damage)
    {
        if (calculator.GetComponent<TestCalculatorHandler>().damage.isOn)
        {
            if (poisoned) { damage = damage + 1; }
            remainingHealth = remainingHealth - damage + shield;
            if (remainingHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                healthText.text = remainingHealth + "/" + maxHealth;
            }
        }
        else if (calculator.GetComponent<TestCalculatorHandler>().heal.isOn)
        {
            if (poisoned == true || wounded == true)
            {
                conditions[0].SetActive(false);
                conditions[1].SetActive(false);
                poisoned = false;
                wounded = false;
            }
            else
            {
                remainingHealth = remainingHealth + damage;
                if (remainingHealth > maxHealth)
                {
                    remainingHealth = maxHealth;
                    healthText.text = remainingHealth + "/" + maxHealth;
                }
                else
                {
                    healthText.text = remainingHealth + "/" + maxHealth;
                }
            }
        }
        else
        {
            remainingHealth = remainingHealth - damage;
            if (remainingHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                healthText.text = remainingHealth + "/" + maxHealth;
            }
        }

    }

    public void CurrentTurn()
    {
        if (currentTurn)
        {
            ApplyConditionEffect();
        }
    }

    private void RemoveCondition()
    {
        foreach (GameObject condition in waningConditions)
        {
            condition.SetActive(false);
        }
        waningConditions.Clear();
    }

    public void AddCondition(List<GameObject> conds)
    {
        foreach (GameObject cond in conds)
        {
            foreach (GameObject condition in conditions)
            {
                if (condition.name == cond.name)
                {
                    condition.SetActive(true);
                }
            }
        }
    }

    private void ApplyConditionEffect()
    {
        foreach (GameObject condition in conditions)
        {
            if (condition.activeSelf)
            {
                switch (condition.name)
                {
                    case "Poisoned":
                        // See HealthHandler(int damage);
                        break;
                    case "Wounded":
                        remainingHealth = remainingHealth - 1;
                        healthText.text = remainingHealth + "/" + maxHealth;
                        break;
                    case "Dazed":
                        //Skip Turn.
                        waningConditions.Add(condition);
                        break;
                    case "Muddled":
                        //DisAdvantage = true;
                        waningConditions.Add(condition);
                        break;
                    case "Crippled":
                        waningConditions.Add(condition);
                        break;
                    case "Disarmed":
                        //No Attack Action?
                        waningConditions.Add(condition);
                        break;
                    case "Cursed":
                        //modifierDeck.Add(CursedCard);
                        waningConditions.Add(condition);
                        break;
                    case "Blessed":
                        //modifierDeck.Add(BlessedCard);
                        waningConditions.Add(condition);
                        break;
                    case "Strengthend":
                        //DisAdvantage = true;
                        waningConditions.Add(condition);
                        break;
                    case "Invisible":
                        waningConditions.Add(condition);
                        break;
                }
            }
        }
    }
}
