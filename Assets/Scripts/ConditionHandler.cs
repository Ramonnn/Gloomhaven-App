//using System.Collections;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using UnityEngine;
//using UnityEngine.UI;

//public class ConditionHandler : MonoBehaviour
//{

//    public List<GameObject> conditions = new List<GameObject>();
//    private ModifierDrawCard modifierDrawCard;
//    private LoadMonsterData monsterData;
//    private int maxHealth;
//    private bool muddled, dazed, crippled, disarmed, strengthend, invisible;

//    private void Start()
//    {
//        modifierDrawCard = GameObject.FindGameObjectWithTag("Combat Modifier").GetComponent<ModifierDrawCard>();
//        monsterData = gameObject.transform.parent.transform.parent.GetComponentInParent<LoadMonsterData>();
//    }

//    void OnEnable()
//    {
//        EnemyHandler.OnClicked += ConditionUpdate;
//    }

//    void OnDisable()
//    {
//        EnemyHandler.OnClicked -= ConditionUpdate;
//    }

//    public void ConditionUpdate()
//    {
//        if (gameObject.transform.GetChild(4).GetComponent<Toggle>().isOn == true)
//        {
//            foreach (GameObject condition in conditions)
//            {
//                if (condition.name == "Wounded" && condition.activeSelf)
//                {
//                    if (gameObject.transform.parent.name == "Elite")
//                    {
//                        int.TryParse(monsterData.genericStatsElite[0], out maxHealth);
//                    }
//                    else if (gameObject.transform.parent.name == "Normal")
//                    {
//                        int.TryParse(monsterData.genericStatsNormal[0], out maxHealth);
//                    }

//                    int howManyDigits = gameObject.transform.GetChild(1).GetComponent<Text>().text.IndexOf("/");
//                    int remainingHealth;
//                    int.TryParse(gameObject.transform.GetChild(1).GetComponent<Text>().text.Substring(howManyDigits + 1, gameObject.transform.GetChild(1).GetComponent<Text>().text.Length - 1 - howManyDigits), out remainingHealth);
//                    remainingHealth = remainingHealth - 1;
//                    gameObject.transform.GetChild(1).GetComponent<Text>().text = Regex.Replace(gameObject.transform.GetChild(1).GetComponent<Text>().text, "\\d+\\/\\d+", maxHealth.ToString() + "/" + remainingHealth.ToString());
//                }
//                if (condition.name == "Poisoned" && condition.activeSelf)
//                {
//                    //Add modifier to ActivateCalcPop.cs
//                }
//                if (condition.name == "Dazed" && condition.activeSelf)
//                {
//                    gameObject.transform.parent.GetComponentInParent<EnemyHandler>().FocusEnemy();
//                    dazed = true;

//                }
//                if (condition.name == "Muddled" && condition.activeSelf)
//                {
//                    modifierDrawCard.drawTwo = true;
//                    muddled = true;

//                }
//                if (condition.name == "Crippled" && condition.activeSelf)
//                {
//                    crippled = true;
//                }
//                if (condition.name == "Disarmed" && condition.activeSelf)
//                {
//                    disarmed = true;
//                }
//                if (condition.name == "Cursed" && condition.activeSelf)
//                {
//                    //CURSE – If a figure is cursed, it must shuffle a CURSE card into its remaining attack modifier deck. When this card is revealed through one of the figure’s attacks, it is removed from the deck instead of being placed into the attack modifier discard pile. A maximum of 10 curse cards can be placed into the modifier deck.

//                }
//                if (condition.name == "Blessed" && condition.activeSelf)
//                {
//                    //BLESS - See Curse.

//                }
//                if (condition.name == "Strengthend" && condition.activeSelf)
//                {
//                    modifierDrawCard.drawTwo = true;
//                    strengthend = true;
//                }
//                if (condition.name == "Invisible" && condition.activeSelf)
//                {
//                    invisible = true;
//                }
//            }
//        }
//        if (gameObject.transform.GetChild(4).GetComponent<Toggle>().isOn == false && gameObject.transform.GetChild(4).GetComponent<Toggle>().interactable == false)
//        {
//            if (muddled)
//            {
//                conditions[3].SetActive(false);
//                muddled = false;
//            }
//            if (dazed)
//            {
//                conditions[2].SetActive(false);
//                dazed = false;
//            }
//            if (crippled)
//            {
//                conditions[4].SetActive(false);
//                crippled = false;
//            }
//            if (disarmed)
//            {
//                conditions[5].SetActive(false);
//                disarmed = false;
//            }
//            if (strengthend)
//            {
//                conditions[8].SetActive(false);
//                strengthend = false;
//            }
//            if (invisible)
//            {
//                conditions[9].SetActive(false);
//                invisible = false;
//            }

//        }
//    }

//}
