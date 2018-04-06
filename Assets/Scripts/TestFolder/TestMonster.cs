using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonster : MonoBehaviour
{
    public TestCurrentMonsters currentMonster;
    public TestMonsterPanel monsterPanel;
    public ModifierDrawCard modifierDrawDeck;
    public GameObject calculator;
    public Text healthText;
    public List<GameObject> enemyConditions = new List<GameObject>();
    public List<GameObject> activeEnemyConditions = new List<GameObject>();
    public List<GameObject> waningConditions = new List<GameObject>();
    public Toggle currentTurn;
    public Image[] shieldValues;
    public int remainingHealth, maxHealth, shield;
    public bool poisoned, wounded, dazed, muddled, strengthend;

    private void OnDisable()
    {
        FreshEnemy();
    }

    public void FreshEnemy()
    {
        foreach (GameObject condition in enemyConditions)
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
                enemyConditions[0].SetActive(false);
                enemyConditions[1].SetActive(false);
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
        currentTurn.isOn = true;
        ApplyConditionEffect();
        if (muddled != strengthend)
        {
            modifierDrawDeck.drawTwo = true;
        }
    }

    public void RemoveCondition()
    {
        foreach (GameObject condition in waningConditions)
        {
            condition.SetActive(false);
        }
        waningConditions.Clear();
    }

    public void AddCondition(List<GameObject> activeconditions)
    {
        foreach (GameObject activecondition in activeconditions)
        {
            foreach (GameObject condition in enemyConditions)
            {
                if (condition.name == activecondition.name && !activeEnemyConditions.Contains(condition))
                {
                    activeEnemyConditions.Add(condition);
                    condition.SetActive(true);
                }
            }
        }
    }

    private void ApplyConditionEffect()
    {
        foreach (GameObject condition in enemyConditions)
        {
            if (condition.activeSelf)
            {
                switch (condition.name)
                {
                    case "Poisoned":
                        poisoned = true;
                        // See HealthHandler(int damage);
                        break;
                    case "Wounded":
                        wounded = true;
                        remainingHealth = remainingHealth - 1;
                        healthText.text = remainingHealth + "/" + maxHealth;
                        break;
                    case "Dazed":
                        dazed = true;
                        waningConditions.Add(condition);
                        break;
                    case "Muddled":
                        muddled = true;
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
                        modifierDrawDeck.standardModifierDeck.Add(modifierDrawDeck.curse);
                        modifierDrawDeck.curseModifier.SetActive(true);
                        waningConditions.Add(condition);
                        break;
                    case "Blessed":
                        modifierDrawDeck.standardModifierDeck.Add(modifierDrawDeck.bless);
                        modifierDrawDeck.blessModifier.SetActive(true);
                        waningConditions.Add(condition);
                        break;
                    case "Strengthend":
                       strengthend = true;
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
