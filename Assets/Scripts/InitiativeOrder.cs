using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeOrder : MonoBehaviour
{

    public List<GameObject> enemiesSetInitiative = new List<GameObject>();

    public void SetInitiativeOrder()
    {
        enemiesSetInitiative.Clear(); //this can be put in a parent object so this is not executed every time. Or it can stay here if I want dynamic enemy type introduction during the game...
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            enemiesSetInitiative.Add(gameObject.transform.GetChild(i).gameObject);
        }

        //enemiesSetInitiative.Sort((p1, p2) => p1.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<DrawCard>().intInitiative.CompareTo(p2.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<DrawCard>().intInitiative));

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            foreach (GameObject enemy in enemiesSetInitiative)
            {
                if (enemy == gameObject.transform.GetChild(i).gameObject)
                {
                    gameObject.transform.GetChild(i).SetSiblingIndex(enemiesSetInitiative.IndexOf(enemy));
                }

            }
        }
    }
}
