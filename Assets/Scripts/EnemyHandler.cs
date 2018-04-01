using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHandler : MonoBehaviour
{
    public List<GameObject> allElites = new List<GameObject>();
    public List<GameObject> allActiveElites = new List<GameObject>();
    public List<GameObject> allActiveLegacyElites;
    public List<GameObject> allActiveUpdateElites = new List<GameObject>();

    public List<GameObject> allNormals = new List<GameObject>();
    public List<GameObject> allActiveNormals = new List<GameObject>();
    public List<GameObject> allActiveLegacyNormals;
    private List<GameObject> allActiveUpdateNormals = new List<GameObject>();

    private bool adaptionChecker;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    public void ClickerTester()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }

    void OnEnable()
    {
        OnClicked += FocusEnemy;
    }

    void OnDisable()
    {
        OnClicked -= FocusEnemy;
    }

    public void AddToActivePool()
    {
        allActiveElites.Clear();
        for (int i = 0; i < allElites.Count; i++)
        {
            if (allElites[i].transform.gameObject.activeSelf == true && !allActiveElites.Contains(allElites[i].gameObject))
            {
                allActiveElites.Add(allElites[i].gameObject);
            }
        }
        for (int i = 0; i < allNormals.Count; i++)
        {
            if (allNormals[i].transform.gameObject.activeSelf == true && !allActiveNormals.Contains(allNormals[i].gameObject))
            {
                allActiveNormals.Add(allNormals[i].gameObject);
            }
        }
        allActiveElites.Sort((p1, p2) => p1.name.CompareTo(p2.name));
        allActiveNormals.Sort((p1, p2) => p1.name.CompareTo(p2.name));
        adaptionChecker = true;
    }

    public void FocusEnemy()
    {
        for (int i = 0; i < allActiveElites.Count; i++)
        {
            if (allActiveElites[i].activeSelf == false)
            {
                allActiveElites.RemoveAt(i);
            }
        }
        if (adaptionChecker == true)
        {
            adaptionChecker = false;
            allActiveLegacyElites = new List<GameObject>(allActiveElites);
            allActiveLegacyNormals = new List<GameObject>(allActiveNormals);

            for (int i = 0; i < allActiveLegacyElites.Count; i++)
            {
                if (!allActiveUpdateElites.Contains(allActiveLegacyElites[i].gameObject) && allActiveLegacyElites[i].transform.GetChild(4).GetComponent<Toggle>().IsInteractable())
                {
                    allActiveUpdateElites.Add(allActiveLegacyElites[i].gameObject);
                }
            }
            allActiveUpdateElites.Sort((p1, p2) => p1.name.CompareTo(p2.name));

            for (int i = 0; i < allActiveLegacyNormals.Count; i++)
            {
                if (!allActiveUpdateNormals.Contains(allActiveLegacyNormals[i].gameObject) && allActiveLegacyNormals[i].transform.GetChild(4).GetComponent<Toggle>().IsInteractable())
                {
                    allActiveUpdateNormals.Add(allActiveLegacyNormals[i].gameObject);
                }
            }
            allActiveUpdateNormals.Sort((p1, p2) => p1.name.CompareTo(p2.name));

        }

        if (allActiveUpdateElites.Count == 0)
        {
            gameObject.GetComponent<ToggleGroup>().SetAllTogglesOff();

            if (allActiveUpdateNormals.Count == 0)
            {
                gameObject.GetComponent<ToggleGroup>().SetAllTogglesOff();
                gameObject.transform.parent.GetChild(7).transform.GetComponent<Button>().interactable = false;
            }
            else
            {
                allActiveUpdateNormals[0].transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                allActiveUpdateNormals[0].transform.GetChild(4).GetComponent<Toggle>().interactable = false;
                allActiveUpdateNormals.RemoveAt(0);
            }
        }
        else
        {
            allActiveUpdateElites[0].transform.GetChild(4).GetComponent<Toggle>().isOn = true;
            allActiveUpdateElites[0].transform.GetChild(4).GetComponent<Toggle>().interactable = false;
            allActiveUpdateElites.RemoveAt(0);
        }
    }



}
