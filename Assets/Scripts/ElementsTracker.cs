using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementsTracker : MonoBehaviour
{

    private List<GameObject> elementsTracker = new List<GameObject>();
    private GameObject clickedElement;
    public GameObject roundButton;

    void Start()
    {
        foreach (Transform element in gameObject.transform.GetChild(0))
        {
            elementsTracker.Add(element.gameObject);
            Debug.Log(elementsTracker.Count);
        }
    }


    public void UpdateElements()
    {
        for (int i = 0; i < elementsTracker.Count; i++)
        {
            if (elementsTracker[i].GetComponent<Toggle>().isOn)
            {
                elementsTracker[i].GetComponent<Toggle>().isOn = false;
                elementsTracker[i].transform.GetChild(0).transform.gameObject.SetActive(true);
            }
            else if (elementsTracker[i].transform.GetChild(0).transform.gameObject.activeSelf)
            {
                elementsTracker[i].transform.GetChild(0).transform.gameObject.SetActive(false);
            }

        }
    }

    public void ConsumeElement()
    {
        clickedElement = EventSystem.current.currentSelectedGameObject;
        if (clickedElement.name != roundButton.name)
        {
            if (clickedElement.transform.GetChild(0).transform.gameObject.activeSelf && clickedElement.GetComponent<Toggle>().isOn == false)
            {
                clickedElement.transform.GetChild(0).transform.gameObject.SetActive(false);
            }
            else if (clickedElement.transform.GetChild(0).transform.gameObject.activeSelf == false && clickedElement.GetComponent<Toggle>().isOn == false)
            {
                clickedElement.transform.GetChild(0).transform.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
