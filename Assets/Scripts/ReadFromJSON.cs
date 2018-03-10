using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ReadFromJSON : MonoBehaviour
{

    private string scenariosFileName = "scenarios.json";
    private string decksFileName = "test.json";

    // Use this for initialization
    void Start()
    {
        LoadScenarioData();
        LoadDeckData();
    }

    private void LoadScenarioData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            ScenarioList loadedScenarios = JsonUtility.FromJson<ScenarioList>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    private void LoadDeckData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, decksFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            DecksList loadedDecks = JsonUtility.FromJson<DecksList>(dataAsJson);
            Debug.Log(loadedDecks.decks[1].cards[1].modifiers[2].cardlines[1]);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
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
    public List<CardL> cards;
}

[System.Serializable]
public struct CardL
{
    public List<Modifier> modifiers;
}

[System.Serializable]
public struct Modifier
{
    public bool shuffle;
    public string initiative;
    public List<String> cardlines;

}
