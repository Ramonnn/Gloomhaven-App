using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScenario : MonoBehaviour
{

    public string selectedScenario;
    public Dictionary<string, string[]> scenarioList;
    public string[] enemyNames;
    public GameObject card, newDeck;

    // Use this for initialization
    private void Awake()
    {
        scenarioList = GetComponent<ScenarioCollection>().scenarios;
    }

    void Start()
    {
        DeckSpawner();
    }

    public void DeckSpawner()
    {
        selectedScenario = PlayerPrefs.GetString("ChosenScenario");

        foreach (KeyValuePair<string, string[]> item in scenarioList)
        {
            if (selectedScenario == item.Key)
            {
                Debug.Log("The Scenario is " + item.Key);
                enemyNames = item.Value;
                for (int i = 0; i < item.Value.Length; i++)
                {
                    Debug.Log("Spawning Deck For " + enemyNames[i]);
                    newDeck = Instantiate(card, GameObject.Find("DeckSpawn" + (i + 1)).transform.position, Quaternion.identity) as GameObject;
                    newDeck.transform.parent = GameObject.Find("DeckSpawn" + (i + 1)).transform;
                    newDeck.name = enemyNames[i];
                }
            }
        }
    }
}