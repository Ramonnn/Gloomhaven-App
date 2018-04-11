using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementsTracker : MonoBehaviour
{

    public List<GameObject> elementsTracker = new List<GameObject>();
    private GameObject clickedElement;

    void OnEnable()
    {
        RoundTracker.TrackingRound += UpdateElements;
    }

    void OnDisable()
    {
        RoundTracker.TrackingRound -= UpdateElements;
    }

    public void UpdateElements()
    {
        for (int i = 0; i < elementsTracker.Count; i++)
        {
            if (elementsTracker[i].GetComponent<Element>().eleSelected.enabled)
            {
                elementsTracker[i].GetComponent<Element>().eleSelected.enabled = false;
                elementsTracker[i].GetComponent<Element>().eleWaning.enabled = true;
            }
            else if (elementsTracker[i].GetComponent<Element>().eleWaning.enabled)
            {
                elementsTracker[i].GetComponent<Element>().eleWaning.enabled = false;
            }

        }
    }
}
