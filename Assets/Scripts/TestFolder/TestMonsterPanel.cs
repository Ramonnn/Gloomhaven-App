using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonsterPanel : MonoBehaviour
{

    public Types panelMonsters;
    public List<GameObject> activeMonsters = new List<GameObject>();
    private int final, current;
    public Text buttonText;
    public Button button;

    public void CycleThroughTurns()
    {
        if (activeMonsters.Count != 0)
        {
            if (buttonText.text == "Start Turn")
            {
                final = activeMonsters.Count - 1;
                current = 0;
            }
            if (current > 0)
            {
                activeMonsters[current - 1].GetComponent<TestMonster>().currentTurn.isOn = false;
                activeMonsters[current - 1].GetComponent<TestMonster>().currentTurn.interactable = false;
                activeMonsters[current - 1].GetComponent<TestMonster>().RemoveCondition();
            }
            buttonText.text = "Next Enemy";
            activeMonsters[current].GetComponent<TestMonster>().CurrentTurn();

            if (activeMonsters[current].GetComponent<TestMonster>().dazed)
            {
                buttonText.text = "Dazed: Skip";
            }
            if (current == final)
            {
                //activeMonsters[current].GetComponent<TestMonster>().currentTurn.interactable = false;
                buttonText.text = "Turn Complete";
                button.interactable = false;
            }
            else
            {
                current++;
            }
        }
    }
}

[System.Serializable]
public struct Types
{
    public List<GameObject> Normals;
    public List<GameObject> Elites;
}