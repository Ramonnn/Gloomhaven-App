using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ActivateCalcPop : MonoBehaviour
{
    private string enemyClickedType;
    private GameObject clickedEnemy;
    public int maxHealth;
    private int newHealth;

    private LoadMonsterData monsterData;

    private List<GameObject> calcConditions = new List<GameObject>();

    public EnemyHandler enemyHandler;

    private void Start()
    {
        monsterData = GetComponentInParent<LoadMonsterData>();
        foreach (Transform condition in gameObject.transform.GetChild(2))
        {
            calcConditions.Add(condition.gameObject);
        }
    }

    public void OpenCalcPop()
    {
        // Maybe I can merge this and type to EventSystem.currenc.curentSelectedGameObject(.gameObject)
        enemyClickedType = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        clickedEnemy = EventSystem.current.currentSelectedGameObject; //this is what I mean...


        for (int i = 0; i < calcConditions.Count; i++)
        {
            if (calcConditions[i].GetComponent<Toggle>().isOn)
            {
                calcConditions[i].GetComponent<Toggle>().isOn = false;
            }
            if (clickedEnemy.transform.GetChild(2).transform.GetChild(i).transform.gameObject.activeSelf)
            {
                calcConditions[i].transform.GetChild(0).transform.gameObject.SetActive(true);
            }
            if (clickedEnemy.transform.GetChild(2).transform.GetChild(i).transform.gameObject.activeSelf == false)
            {
                calcConditions[i].transform.GetChild(0).transform.gameObject.SetActive(false);
            }

        }

        gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text = "";
        gameObject.SetActive(true);
    }

    public void CloseCalcPop()
    {
        gameObject.SetActive(false);
        CalculateDMG(enemyClickedType);
        Debug.Log(clickedEnemy);

        for (int i = 0; i < enemyHandler.allActiveElites.Count; i++)
        {
            if (enemyHandler.allActiveElites[i].activeSelf == false)
            {
                enemyHandler.allActiveElites.RemoveAt(i);
            }
        }
    }

    private void CalculateDMG(string enemytype)
    {
        if (enemytype == "Elite")
        {
            int.TryParse(monsterData.genericStatsElite[0], out maxHealth);
        }
        else if (enemytype == "Normal")
        {
            int.TryParse(monsterData.genericStatsNormal[0], out maxHealth);
        }

        int howManyDigits = clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.IndexOf("/");
        int remainingHealth;
        int.TryParse(clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.Substring(howManyDigits + 1, clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.Length - 1 - howManyDigits), out remainingHealth);
        int damageAmount;
        int.TryParse(gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text, out damageAmount);

        if (gameObject.transform.GetChild(1).transform.GetChild(10).GetComponent<Toggle>().isOn)
        {
            if (damageAmount >= remainingHealth)
            {
                clickedEnemy.SetActive(false);
            }
            else
            {
                //if (gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text != "" && clickedEnemy.transform.GetChild(3).transform.GetChild(1).transform.gameObject.activeSelf) //Poisoned
                //{
                //    damageAmount = damageAmount + 1;
                //}
                newHealth = remainingHealth - damageAmount;
                clickedEnemy.transform.GetChild(1).GetComponent<Text>().text = Regex.Replace(clickedEnemy.transform.GetChild(1).GetComponent<Text>().text, "\\d+\\/\\d+", maxHealth.ToString() + "/" + newHealth.ToString());

            }

        }
        else
        {
            if (damageAmount + remainingHealth >= maxHealth)
            {
                newHealth = maxHealth;
            }
            else
            {
                newHealth = remainingHealth + damageAmount;
            }
            clickedEnemy.transform.GetChild(1).GetComponent<Text>().text = Regex.Replace(clickedEnemy.transform.GetChild(1).GetComponent<Text>().text, "\\d+\\/\\d+", maxHealth.ToString() + "/" + newHealth.ToString());
        }


        ApplyCondition();

        //IMPORTANT! If you do multiple attacks there are multiple poison ticks. So I need to implement a + button into the calculator to indicate multiple attacks.


        // The condition remains on the figure until the requirements for removing the specific effect are met. 
        // Only one of each condition type may be applied to any single figure at a time, however conditions can be reapplied to refresh their duration.

        // If an ability has the name of one of these conditions contained within it, then the condition is applied to all targets of the ability, after the main effect of the ability is applied.
        // Conditions are applied regardless of whether the corresponding attack does damage.


        //POISON – If a figure is poisoned, all enemies add +1 Attack to all of their attacks targeting the figure. If a Heal ability is used on a poisoned figure, the POISON token is removed, and the Heal has no other effect.
        //WOUND – If a figure is wounded, it suffers one point of damage at the start of each of its turns. If a Heal ability is used on a wounded figure, the WOUND token is removed and the Heal continues normally. If a figure is both poisoned and wounded, a Heal ability would remove both conditions but have no other effect.
        //IMMOBILIZE – If a figure is immobilized, it cannot perform any move abilities on its turn. At the end of its next turn, the IMMOBILIZE token is removed.
        //DISARM – If a figure is disarmed, it cannot perform any attack abilities on its turn. At the end of its next turn, the DISARM token is removed.
        //STUN – If a figure is stunned, it cannot perform any abilities or use items on its turn except to perform a long rest(in the case of characters). At the end of its next turn, the STUN token is removed.
        //MUDDLE – If a figure is muddled, it gains Disadvantage on all of its attacks. At the end of its next turn, the MUDDLE token is removed.
        //CURSE – If a figure is cursed, it must shuffle a CURSE card into its remaining attack modifier deck.When this card is revealed through one of the figure’s attacks, it is removed from the deck instead of being placed into the attack modifier discard pile. A maximum of 10 curse cards can be placed into the modifier deck.
        //INVISIBLE – If a figure is invisible, it cannot be focused on or targeted by an enemy. At the end of its next turn, the INVISIBLE token is removed.
        //STRENGTHEN – If a figure is strengthened, it gains Advantage on all of its attacks. At the end of its next turn, the STRENGTHEN token is removed.
        //BLESS - See Curse.

        //SHIELD - A “Shield X” bonus ability gives the recipient a defender’s bonus that reduces any incoming attack value by X. Multiple shield bonuses stack with one another and can be applied in any order. A shield bonus only applies to damage caused by an attack.
        //RETALIATE - Manually by players.
        //HEAL - Manually by players.
    }

    private void ApplyCondition()
    {
        for (int x = 0; x < calcConditions.Count; x++)
        {
            if (calcConditions[x].GetComponent<Toggle>().isOn)
            {
                for (int i = 0; i < clickedEnemy.transform.GetChild(2).childCount; i++)
                {
                    if (clickedEnemy.transform.GetChild(2).transform.GetChild(i).name == calcConditions[x].name)
                    {
                        clickedEnemy.transform.GetChild(2).transform.GetChild(i).transform.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    private void RemoveCondition() //to do
    {
        for (int x = 0; x < calcConditions.Count; x++)
        {
            if (calcConditions[x].GetComponent<Toggle>().isOn)
            {
                for (int i = 0; i < clickedEnemy.transform.GetChild(2).childCount; i++)
                {
                    if (clickedEnemy.transform.GetChild(2).transform.GetChild(i).name == calcConditions[x].name)
                    {
                        clickedEnemy.transform.GetChild(2).transform.GetChild(i).transform.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
