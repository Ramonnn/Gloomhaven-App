using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public string chosenScenario;
    public int numberOfPlayers, scenarioLevel;

    public void SubmitSettings()
    {
        chosenScenario = GameObject.Find("Scenario").GetComponentInChildren<TextMeshProUGUI>().text;

        PlayerPrefs.SetString("ChosenScenario", chosenScenario);
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
        PlayerPrefs.SetInt("ScenarioLevel", scenarioLevel);

        SceneManager.LoadScene("GameScene");
    }
}
