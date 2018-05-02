using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

public class ScenarioList : MonoBehaviour
{

    private string scenariosFileName = "testscenarios.json";
    private JSONNode SCENARIOSTATS;
    public List<string> options;
    public Dropdown scenarioList;

    public string result = "";
    public string filePath;

    IEnumerator Example()
    {
        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();
            result = www.downloadHandler.text;
        }
        else
            result = System.IO.File.ReadAllText(filePath);
    }

    private void Awake()
    {
        filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "testscenarios.json");
        StartCoroutine(Example());
        SCENARIOSTATS = JSON.Parse(result);
        //string filePath = Path.Combine(Application.streamingAssetsPath, scenariosFileName);

        //if (File.Exists(filePath))
        //{
        //string dataAsJson = File.ReadAllText(filePath);
        //SCENARIOSTATS = JSON.Parse(dataAsJson);

        //    foreach (KeyValuePair<string, JSONNode> scenario in SCENARIOSTATS["scenarios"])
        //    {
        //        options.Add(scenario.Value[0]);
        //    }
        //    scenarioList.AddOptions(options);
        //}
        //else
        //{
        //    Debug.LogError("Cannot load Scenario data!");
        //}

        foreach (KeyValuePair<string, JSONNode> scenario in SCENARIOSTATS["scenarios"])
        {
            options.Add(scenario.Value[0]);
        }
        scenarioList.AddOptions(options);
    }
}
