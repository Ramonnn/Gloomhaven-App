using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFromJSON : MonoBehaviour
{

    private string scenariosFileName = "scenarios.json";

    // Use this for initialization
    void Start()
    {
        LoadGameData();
    }

    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            ScenarioList loadedData = JsonUtility.FromJson<ScenarioList>(dataAsJson);
            Debug.Log("I'm loading" + loadedData.scenarios[0].name);

        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}

[System.Serializable]
public class ScenarioList
{
    public List<Scenario> scenarios;
}

[System.Serializable]
public class Scenario
{
    public string name;
    public List<Monster> decks;
}

[System.Serializable]
public class Monster
{
    public string name;
}