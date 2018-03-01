using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScenario : MonoBehaviour
{

    public string selectedScenario;
    public Dictionary<string, string[]> scenarioList;

    // Use this for initialization
    void Start()
    {
        scenarioList = GetComponentInParent<ScenarioCollection>().scenarios;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScenarioSelect()
    {
        selectedScenario = GameObject.Find("Scenario").GetComponentInChildren<TextMeshProUGUI>().text;

        foreach (KeyValuePair<string, string[]> item in scenarioList)
        {
            if (selectedScenario == item.Key)
            {
                Debug.Log("The Scenario is " + item.Key + " and the enemies will be " + item.Value);
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
