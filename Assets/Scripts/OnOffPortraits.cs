using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffPortraits : MonoBehaviour {

    public Image selectedPortrait, deselectedPortrait;
    public GameObject enemyFrame;

    public void PortraitToggle()
    {
        if (!gameObject.GetComponent<Toggle>().isOn)
        {
            enemyFrame.SetActive(false);
        }
        else
        {
            enemyFrame.SetActive(true);
        }
    }

}
