using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

public class ScenarioList : MonoBehaviour
{

    private string scenariosFileName = "scenarios.json";
    private JSONNode SCENARIOSTATS;
    public List<string> options;
    public Dropdown scenarioList;

    private void Awake()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            SCENARIOSTATS = JSON.Parse(dataAsJson);

            foreach (KeyValuePair<string, JSONNode> scenario in SCENARIOSTATS["scenarios"])
            {
                options.Add(scenario.Value[0]);
            }
            scenarioList.AddOptions(options);
        }
        else
        {
            Debug.LogError("Cannot load Scenario data!");
        }

    }
}
