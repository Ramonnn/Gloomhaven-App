using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class TestLoadScenario : MonoBehaviour //Script Execution Order Adjusted -100 from default
{
    private string scenariosFileName = "testscenarios.json";
    private JSONNode SCENARIOSTATS;
    public List<string> scenarioMonsters = new List<string>();
    public TestCurrentScenario currentScenario;

    private void Awake()
    {
        LoadScenarioData(PlayerPrefs.GetString("ChosenScenario"));
        Debug.Log(PlayerPrefs.GetString("ChosenScenario"));
    }

    private void LoadScenarioData(string selectedscenario)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            SCENARIOSTATS = JSON.Parse(dataAsJson);

            foreach (KeyValuePair<string, JSONNode> scenario in SCENARIOSTATS["scenarios"])
            {
                if (scenario.Value["name"] == selectedscenario)
                {
                    for (int i = 0; i < scenario.Value["decks"].Count; i++)
                    {
                        scenarioMonsters.Add(scenario.Value["decks"][i]["name"]);
                    }
                }
            }
            currentScenario = new TestCurrentScenario(selectedscenario, scenarioMonsters);
        }
        else
        {
            Debug.LogError("Cannot load Scenario data!");
        }
    }
}