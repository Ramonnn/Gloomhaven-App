using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    Text inputField;

    public void ButtonPressed()
    {
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;

        inputField.text += buttonValue;
    }

    public void BackSpacePressed()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public void ClearPressed()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0,0);
        }
    }
}
