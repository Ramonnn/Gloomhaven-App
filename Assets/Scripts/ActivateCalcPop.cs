using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ActivateCalcPop : MonoBehaviour
{
    private string enemyClicked, enemyClickedType;
    private GameObject clickedEnemy;
    public NormalHandler normalHandler;
    public EliteHandler eliteHandler;
    public int maxHealth;

    public void OpenCalcPop()
    {
        gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text = null;
        gameObject.SetActive(true);
        enemyClicked = EventSystem.current.currentSelectedGameObject.name;
        enemyClickedType = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        clickedEnemy = EventSystem.current.currentSelectedGameObject;
    }

    public void CloseCalcPop()
    {
        gameObject.SetActive(false);
        CalculateDMG(enemyClicked, enemyClickedType);
    }

    private void CalculateDMG(string enemynumber, string enemytype)
    {
        if (enemytype == "Elite")
        {
            int.TryParse(eliteHandler.maxHealth, out maxHealth);
        }
        else if (enemytype == "Normal")
        {
            int.TryParse(normalHandler.maxHealth, out maxHealth);
        }

        int howManyDigits = clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.IndexOf("/");
        int remainingHealth;
        int.TryParse(clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.Substring(howManyDigits + 1, clickedEnemy.transform.GetChild(1).GetComponent<Text>().text.Length - 1 - howManyDigits), out remainingHealth);

        int damageAmount;
        int.TryParse(gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text, out damageAmount);

        if (damageAmount >= remainingHealth)
        {
            clickedEnemy.SetActive(false);
        }
        else
        {
            int newHealth = remainingHealth - damageAmount;
            clickedEnemy.transform.GetChild(1).GetComponent<Text>().text = Regex.Replace(clickedEnemy.transform.GetChild(1).GetComponent<Text>().text, "\\d+\\/\\d+", maxHealth.ToString() + "/" + newHealth.ToString());
        }

        //If shielded
        //If poisoned
        //If net damage amount > remaining health : remaining health = max health, clear conditions, setActive(false)
    }
}
