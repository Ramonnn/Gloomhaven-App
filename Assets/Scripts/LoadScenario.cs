using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScenario : MonoBehaviour
{

    public string selectedScenario;
    public Dictionary<string, string[]> scenarioList;
    public GameObject[] spawnPoints;
    public GameObject card;

    // Use this for initialization
    void Start()
    {
        scenarioList = GetComponent<ScenarioCollection>().scenarios;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        ScenarioLoader();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScenarioLoader()
    {
        selectedScenario = PlayerPrefs.GetString("ChosenScenario");

        foreach (KeyValuePair<string, string[]> item in scenarioList)
        {
            if (selectedScenario == item.Key)
            {
                foreach (string enemyName in item.Value)
                {
                    Debug.Log("Spawning Deck For " + enemyName);
                    //DeckSpawner();
                }
                Debug.Log("The Scenario is " + item.Key);
            }
        }
    }

    //public void DeckSpawner()
    //{
    //    Instantiate(card, spawnPoints[0].transform);
    //    Instantiate(card, spawnPoints[1].transform);
    //    Instantiate(card, spawnPoints[2].transform);
    //    Instantiate(card, spawnPoints[3].transform);
    //}
}