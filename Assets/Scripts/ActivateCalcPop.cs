using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCalcPop : MonoBehaviour
{

    public void OpenCalcPop()
    {
        gameObject.SetActive(true);
    }

    public void CloseCalcPop()
    {
        gameObject.SetActive(false);
    }
}
