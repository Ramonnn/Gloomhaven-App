using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCalculatorHandler : MonoBehaviour
{

    public void CalculatorPopUp()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    //Create Event Listener and subscribe the enemy from enemypanel when (button) clicked on. Unsubscribe after value passthrough and calculator closes.

}
