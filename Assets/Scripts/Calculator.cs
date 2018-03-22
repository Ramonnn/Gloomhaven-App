using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Calculator : MonoBehaviour
{


    [SerializeField]
    Text inputField;

    string inputString;

    public void ButtonPressed()
    {
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;

        inputString += buttonValue;

        inputField.text = inputString;
    }

    public void BackSpacePressed()
    {
        if (inputString.Length > 0)
        {
            inputString = inputString.Substring(0, inputString.Length - 1);
            inputField.text = inputString;
        }
    }

    public void ClearPressed()
    {
        if (inputString.Length > 0)
        {
            inputString = inputString.Substring(0,0);
            inputField.text = inputString;
        }
    }
}
