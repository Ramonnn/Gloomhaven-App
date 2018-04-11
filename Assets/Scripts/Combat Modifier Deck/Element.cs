using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public Image eleSelected, eleWaning;

    public void CycleElement()
    {
        if (!eleSelected.enabled && !eleWaning.enabled)
        {
            eleSelected.enabled = true;
        }
        else if (eleSelected.enabled)
        {
            eleSelected.enabled = false;
            eleWaning.enabled = true;
        }
        else if (eleWaning.enabled)
        {
            eleWaning.enabled = false;
        }

    }
}
