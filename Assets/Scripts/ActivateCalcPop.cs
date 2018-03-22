using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateCalcPop : MonoBehaviour
{
    public string enemyClicked, enemyClickedType;
    public void OpenCalcPop()
    {
        gameObject.SetActive(true);
        enemyClicked = EventSystem.current.currentSelectedGameObject.name;
        enemyClickedType = EventSystem.current.currentSelectedGameObject.transform.parent.name;

    }

    public void CloseCalcPop()
    {
        gameObject.SetActive(false);
    }
}
