using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using TMPro;

public class ScenarioPicker : MonoBehaviour
{
    public string chosenScenario;
    public int numberOfPlayers, scenarioLevel;
    private string scenariosFileName = "scenarios.json";
    public ScenarioList scenarioList;
    public List<String> Options = new List<String>();

    void Start()
    {
        LoadScenarioData();
        LoadScenarioPicker();
    }

    public void LoadScenarioPicker()
    {
        for (int i = 0; i < scenarioList.scenarios.Count; i++)
        {
            Options.Add(scenarioList.scenarios[i].name);
        }

        TMP_Dropdown scenarioPicker = GetComponent<TMP_Dropdown>();
        scenarioPicker.ClearOptions();
        scenarioPicker.AddOptions(Options);
    }

    private void LoadScenarioData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            scenarioList = JsonUtility.FromJson<ScenarioList>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
