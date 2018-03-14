using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LoadScenario : MonoBehaviour
{
    private string scenariosFileName = "scenarios.json";
    private string decksFileName = "decks.json";
    private string monstersFileName = "monsters.json";
    private string monsterStatsFileName = "monsterstats.json";
    public ScenarioList loadedScenarios;
    public DecksList loadedDecks;
    public Monsters loadedMonsters;
    //public MonsterStats loadedMonsterStats;

    public string selectedScenario;
    public List<Scenario> scenarioList;
    public List<Monster> enemyNames;
    public GameObject card, newDeck;
    public string scenarioName;

    private void Awake()
    {
        LoadScenarioData();
        LoadDeckData();
        LoadCombinations();
    }

    void Start()
    {
        scenarioList = loadedScenarios.scenarios;
        ScenarioLoader();
    }

    private void LoadScenarioData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedScenarios = JsonUtility.FromJson<ScenarioList>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Scenario data!");
        }
    }

    private void LoadDeckData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, decksFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            loadedDecks = JsonUtility.FromJson<DecksList>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Deck data!");
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

    ////I have to use SimpleJSON here. File is to big and complicated to manually adjust to Unity's liking. Please Upvote the C#/JSON dictionary conversion implementation on the Unity Support website -.-'
    //private void LoadMonsterStats()
    //{
    //    string filePath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);
    //    if (File.Exists(filePath))
    //    {
    //        string dataAsJson = File.ReadAllText(filePath);
    //        var JSONconscious = JSON.Parse(dataAsJson);
    //        monsters = JSONconscious["monsters"].AsArray; // hmmmm
    //        bosses = JSONconscious["bosses"].AsArray;
    //    }
    //    else
    //    {
    //        Debug.LogError("Cannot load MonsterStats data!");
    //    }
    //}

    public void ScenarioLoader()
    {
        selectedScenario = PlayerPrefs.GetString("ChosenScenario"); // this needs to change from e.g. Scenario 1 to #1 Black Barrows.
        foreach (Scenario item in scenarioList)
        {
            if (selectedScenario == item.name)
            {
                Debug.Log("The Scenario is " + item.name);
                scenarioName = item.name;
                enemyNames = item.decks;

                for (int i = 0; i < enemyNames.Count; i++)
                {
                    Debug.Log("Spawning Deck For " + enemyNames[i].name);
                    newDeck = Instantiate(card, GameObject.Find("DeckSpawn" + (i + 1)).transform.position, Quaternion.identity) as GameObject;
                    newDeck.transform.parent = GameObject.Find("DeckSpawn" + (i + 1)).transform;
                    newDeck.name = enemyNames[i].name;
                }
            }
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

// Load Monster Stats

//[System.Serializable]
//public class MonsterStats
//{
//    public List<IndividualMonster> monster;
//    public List<Boss> bosses;
//}

////[System.Serializable]
////public struct Boss
////{
////    public string name;
////    public List<...> monsters;
////}


//[System.Serializable]
//public struct IndividualMonster
//{
//    string monsterName;
//    public List<Level> monsters;
//}

//[System.Serializable]
//public struct Level
//{
//    public List<Level> monsters;
//}