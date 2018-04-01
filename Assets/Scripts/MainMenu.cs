using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string chosenScenario;
    public int numberOfPlayers, scenarioLevel;

    public void SubmitSettings()
    {
        chosenScenario = GameObject.Find("Scenario").GetComponentInChildren<Text>().text;
        numberOfPlayers = 4;
        scenarioLevel = 1;
        PlayerPrefs.SetString("ChosenScenario", chosenScenario);
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
        PlayerPrefs.SetInt("ScenarioLevel", scenarioLevel);

        SceneManager.LoadScene("GameScene");
    }
}
