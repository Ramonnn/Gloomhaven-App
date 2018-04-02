//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class EnemyPassThrough : MonoBehaviour
//{
//    private bool alreadyFetched = false;
//    private Sprite popUpSprite;
//    private string refreshHealth;
//    private bool enemyDead;

//    private List<GameObject> normalEnemies = new List<GameObject>();
//    private List<GameObject> eliteEnemies = new List<GameObject>();

//    private LoadMonsterData monsterData;

//    private void Start()
//    {
//        monsterData = GetComponentInParent<LoadMonsterData>();

//        foreach (Transform enemy in gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(1))
//        {
//            normalEnemies.Add(enemy.gameObject);
//        }

//        foreach (Transform enemy in gameObject.transform.parent.GetChild(0).transform.GetChild(6).transform.GetChild(0))
//        {
//            eliteEnemies.Add(enemy.gameObject);
//        }
//    }

//    public void FetchPlaceHolders() //On Button Press... Maybe could already do this on scene instantiation? Don't know what is more efficient.
//    {
//        if (alreadyFetched == false)
//        {
//            alreadyFetched = true;
//            for (int i = 0; i < gameObject.transform.childCount - 1; i++)
//            {
//                popUpSprite = GetComponentInParent<LoadMonsterData>().currentMonsterImage;
//                gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = popUpSprite;
//            }
//        }


//        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
//        {
//            foreach (Toggle toggle in gameObject.transform.GetChild(i).GetComponentsInChildren<Toggle>())
//            {
//                if (toggle.isOn && normalEnemies[i].transform.gameObject.activeSelf == false && eliteEnemies[i].transform.gameObject.activeSelf == false)
//                {
//                    gameObject.transform.GetChild(i).transform.GetChild(2).GetComponent<Toggle>().isOn = false;
//                    gameObject.transform.GetChild(i).transform.GetChild(3).GetComponent<Toggle>().isOn = false;
//                }
//            }
//        }


//        transform.parent.GetChild(0).transform.gameObject.SetActive(false);
//        transform.gameObject.SetActive(true);
//    }


//    public void ClosePopUp() //Wish this worked with togglegroup...
//    {
//        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
//        {
//            foreach (Toggle toggle in gameObject.transform.GetChild(i).GetComponentsInChildren<Toggle>())
//            {
//                if (toggle.isOn == true && toggle.name == "Elite" && eliteEnemies[i].activeSelf == false)
//                {
//                    eliteEnemies[i].transform.GetChild(1).GetComponent<Text>().text = monsterData.genericStatsElite[0] + "/" + monsterData.genericStatsElite[0];
//                    eliteEnemies[i].transform.gameObject.SetActive(true);
//                    eliteEnemies[i].transform.GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text;
//                }

//                else if (toggle.isOn == true && toggle.name == "Normal" && normalEnemies[i].activeSelf == false)
//                {
//                    normalEnemies[i].transform.GetChild(1).GetComponent<Text>().text = monsterData.genericStatsNormal[0] + "/" + monsterData.genericStatsNormal[0];
//                    normalEnemies[i].transform.gameObject.SetActive(true);
//                    normalEnemies[i].transform.GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text;
//                }
//                else if (toggle.isOn == false && toggle.name == "Elite" && eliteEnemies[i].transform.gameObject.activeSelf == true)
//                {
//                    eliteEnemies[i].transform.gameObject.SetActive(false);
//                }

//                else if (toggle.isOn == false && toggle.name == "Normal" && normalEnemies[i].transform.gameObject.activeSelf == true)
//                {
//                    normalEnemies[i].transform.gameObject.SetActive(false);
//                }
//            }
//        }
//        transform.parent.GetChild(0).transform.gameObject.SetActive(true);
//        transform.gameObject.SetActive(false);
//    }
//}
