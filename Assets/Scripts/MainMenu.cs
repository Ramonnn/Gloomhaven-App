using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public string chosenScenario;
    public int numberOfPlayers, scenarioLevel;
    public TextMeshProUGUI playerNumber, levelScenario;
    public Text scenario;

    public void SubmitSettings()
    {
        chosenScenario = scenario.text;
        int.TryParse(playerNumber.text, out numberOfPlayers);
        int.TryParse(levelScenario.text, out scenarioLevel);
        PlayerPrefs.SetString("ChosenScenario", chosenScenario);
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
        PlayerPrefs.SetInt("ChosenLevel", scenarioLevel);

        SceneManager.LoadScene("GameScene");
    }
}
