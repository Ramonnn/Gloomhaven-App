using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPassThrough : MonoBehaviour
{
    private bool alreadyFetched = false;
    private Sprite popUpSprite;
    private string refreshHealth;
    private bool enemyDead;

    public EliteHandler eliteHandler; //These scripts can be removed!
    public NormalHandler normalHandler; // These scripts can be removed! Just use public GameObject EnemyFrame to get access to LoadMonsterData and load maxHealth from there. Also do this for the getchildgetchildgetchild bullshit.

    public void FetchPlaceHolders() //On Button Press... Maybe could already do this on scene instantiation? Don't know what is more efficient.
    {
        if (alreadyFetched == false)
        {
            alreadyFetched = true;
            for (int i = 0; i < gameObject.transform.childCount - 1; i++)
            {
                popUpSprite = GetComponentInParent<LoadMonsterData>().currentMonsterImage;
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = popUpSprite;
            }
        }

        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            foreach (Toggle toggle in gameObject.transform.GetChild(i).GetComponentsInChildren<Toggle>())
            {
                if (toggle.isOn && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.gameObject.activeSelf == false && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.gameObject.activeSelf == false)
                {
                    gameObject.transform.GetChild(i).GetComponentInChildren<Toggle>().isOn = false;
                }
            }
        }
        transform.parent.GetChild(0).transform.gameObject.SetActive(false);
        transform.gameObject.SetActive(true);
    }


    public void ClosePopUp() // ToggleGroup itteration doesn't work for some reason. Now I need to add breaks in order for the else statement not to run at unwanted moments... Least elegant code ever.
    {
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            foreach (Toggle toggle in gameObject.transform.GetChild(i).GetComponentsInChildren<Toggle>())
            {
                if (toggle.isOn == true && toggle.name == "Elite" && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.gameObject.activeSelf == false)
                {
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = eliteHandler.maxHealth + "/" + eliteHandler.maxHealth;
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.gameObject.SetActive(true);
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).GetComponentInChildren<Text>().text = gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text;
                    break;
                }

                if (toggle.isOn == true && toggle.name == "Normal" && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.gameObject.activeSelf == false)
                {
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = normalHandler.maxHealth + "/" + normalHandler.maxHealth;
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.gameObject.SetActive(true);
                    gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).GetComponentInChildren<Text>().text = gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text;


                    break;
                }
                else
                {
                    if (toggle.isOn == false && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.gameObject.activeSelf == true)
                    {
                        gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0).transform.GetChild(i).transform.gameObject.SetActive(false);
                    }
                    if (toggle.isOn == false && gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.gameObject.activeSelf == true)
                    {
                        gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetChild(i).transform.gameObject.SetActive(false);
                    }
                }
            }
        }
        transform.parent.GetChild(0).transform.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
