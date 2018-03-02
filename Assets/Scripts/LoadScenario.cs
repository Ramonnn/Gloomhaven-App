using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScenario : MonoBehaviour
{

    public string selectedScenario;
    public Dictionary<string, string[]> scenarioList;
    public GameObject[] spawnPoints;
    public List<Card> cardDeck;
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
                    DeckSpawner(enemyName);
                }
                Debug.Log("The Scenario is " + item.Key);
            }
        }
    }

    public void DeckSpawner(string enemy)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length); //Random Placeholder, should be 'first available slot' (for loop?)
        GameObject newDeck = Instantiate(card, spawnPoints[spawnPointIndex].transform) as GameObject; //This instantiates a copy of the 'Card' GameObject, calling it 'newDeck' (for no good reason)
        cardDeck = DeckCollection.decklist[enemy]; //cardDeck now contains the specific List that contains the cards from an indicated enemydeck (e.g., if enemy is 'Ancient Artillery' it contains the list of card form the 'Ancient Artillery Deck')
        // To connect newDeck with cardDeck so that newDeck can run 'DrawCard.cs' independently on its own unique cardDeck without conflicting with any other instantiations of a newDeck for other enemies...
    }
}