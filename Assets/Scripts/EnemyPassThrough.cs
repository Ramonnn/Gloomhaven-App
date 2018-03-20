using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPassThrough : MonoBehaviour
{
    private Dictionary<string, GameObject> popUpEnemies = new Dictionary<string, GameObject>();
    private bool alreadyFetched = false;
    private Sprite popUpSprite;

    public GameObject enemyShell;

    public void FetchPlaceHolders() //On Button Press... Maybe could already do this on scene instantiation? Don't know what is more efficient.
    {
        if (alreadyFetched == false)
        {
            alreadyFetched = true;
            for (int i = 0; i < gameObject.transform.childCount - 1; i++)
            {
                popUpEnemies.Add(gameObject.transform.GetChild(i).name, gameObject.transform.GetChild(i).gameObject);
                popUpSprite = GetComponentInParent<LoadMonsterData>().currentMonsterImage;
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = popUpSprite;
            }

        }
    }

    public void ClosePopUp() //Communicates that monster# needs to be in the scene as a normal/elite. (Code somewhere else to check whether that monster is new or already in the scene.
    {
        foreach (KeyValuePair<string, GameObject> placeholder in popUpEnemies)
        {
            foreach (Toggle toggle in placeholder.Value.GetComponentsInChildren<Toggle>())
            {
                if (toggle.isOn == true && toggle.name == "Normal")
                {
                    string enemyNumber = placeholder.Value.GetComponentInChildren<Text>().text;
                    string enemyType = toggle.name;
                    InstantiateEnemyShell(enemyType, enemyNumber);
                    Debug.Log("Enemy" + enemyNumber + "is a" + enemyType);
                }
                if (toggle.isOn == true && toggle.name == "Elite")
                {
                    string enemyNumber = placeholder.Value.GetComponentInChildren<Text>().text;
                    string enemyType = toggle.name;
                    InstantiateEnemyShell(enemyType, enemyNumber);
                    Debug.Log("Enemy" + enemyNumber + "is a" + enemyType);
                }


            }

        }
    }

    public void InstantiateEnemyShell(string enemytype, string enemynumber)
    {
        if (enemytype == "Normal")
        {
            Instantiate(enemyShell, gameObject.transform.parent.GetChild(0).GetChild(6).GetChild(0));
            enemyShell.GetComponentInChildren<Text>().text = enemynumber; // THIS DOES NOT WORK. DO THIS IN INDIVIDUAL INSTANTIATIONS (SCRIPT) OF THE ENEMYSHELLS
        }
        if (enemytype == "Elite")
        {
            Instantiate(enemyShell, gameObject.transform.parent.GetChild(0).GetChild(6).GetChild(1));
            enemyShell.GetComponentInChildren<Text>().text = enemynumber; // THIS DOES NOT WORK. DO THIS IN INDIVIDUAL INSTANTIATIONS (SCRIPT) OF THE ENEMYSHELLS
        }
    }
}
