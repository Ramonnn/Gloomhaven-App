using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScenario : MonoBehaviour
{

    public string selectedScenario;
    public List<Scenario> scenarioList;

    // Use this for initialization
    void Start()
    {
        scenarioList = ScenarioCollection.scenarioList;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScenarioSelect()
    {
        selectedScenario = GameObject.Find("Scenario").GetComponentInChildren<TextMeshProUGUI>().text;

        for (int i = 0; i < scenarioList.Count; i++)
        {
            if (selectedScenario == scenarioList[i].scenarioNumber)
            {
                foreach (string item in scenarioList[i])
                {

                }
                Debug.Log("Enemies will be " + scenarioList[i].enemy1 + scenarioList[i].enemy2 + scenarioList[i].enemy3 + scenarioList[i].enemy4 + scenarioList[i].enemy5);
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
