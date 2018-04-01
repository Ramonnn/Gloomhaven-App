using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class LoadScenario : MonoBehaviour //Script Execution Order Adjusted -100 from default
{
    private string scenariosFileName = "scenarios.json";
    private string monstersFileName = "monsters.json";
    public ScenarioList loadedScenarios;
    public Monsters loadedMonsters;

    public List<Monster> enemyNames;
    public GameObject card, newDeck, newEnemyFrame, frame;

    private void Awake()
    {
        LoadScenarioData(PlayerPrefs.GetString("ChosenScenario"));
        LoadCombinations();
    }

    private void LoadScenarioData(string selectedscenario)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedScenarios = JsonUtility.FromJson<ScenarioList>(dataAsJson);

            foreach (Scenario item in loadedScenarios.scenarios)
            {
                if (selectedscenario == item.name)
                {
                    Debug.Log("The Scenario is " + item.name);
                    enemyNames = item.decks;

                    for (int i = 0; i < enemyNames.Count; i++)
                    {
                        Debug.Log("Spawning Deck For " + enemyNames[i].name);
                        newEnemyFrame = Instantiate(frame, GameObject.Find("GridDynamic").transform);
                        newDeck = Instantiate(card, GameObject.Find("DeckSpawn").transform);
                        GameObject RenameSpawn = GameObject.Find("DeckSpawn");
                        RenameSpawn.name = enemyNames[i].name;
                        newDeck.name = enemyNames[i].name;
                        newEnemyFrame.name = enemyNames[i].name;
                        newEnemyFrame.GetComponentInChildren<Text>().text = enemyNames[i].name;
                    }
                }

            }
        }
        else
        {
            Debug.LogError("Cannot load Scenario data!");
        }
    }

    private void LoadCombinations()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, monstersFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedMonsters = JsonUtility.FromJson<Monsters>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Combination data!");
        }
    }
}

// Load Scenario Data

[System.Serializable]
public struct ScenarioList
{
    public List<Scenario> scenarios;
}

[System.Serializable]
public struct Scenario
{
    public string name;
    public List<Monster> decks;
}

[System.Serializable]
public struct Monster
{
    public string name;
}

//Load Deck Data

[System.Serializable]
public struct DecksList
{
    public List<Deck> decks;
}

[System.Serializable]
public struct Deck
{
    public string monsterclass;
    public List<Card> cards;
}

[System.Serializable]
public struct Card
{
    public bool shuffle;
    public string initiative;
    public List<String> cardlines;
}

// Connect Monster with their respective decks

[System.Serializable]
public struct Monsters
{
    public List<Combinations> monsters;
}

[System.Serializable]
public struct Combinations
{
    public string name;
    public string monsterclass;

}