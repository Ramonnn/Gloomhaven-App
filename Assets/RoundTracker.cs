using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTracker : MonoBehaviour {

    private int roundNumber;
	// Use this for initialization
	void Start () {
        roundNumber = 0;
	}


    public void UpdateRoundNumber()
    {
        int.TryParse(gameObject.transform.GetChild(1).transform.GetComponent<Text>().text, out roundNumber);
        roundNumber = roundNumber+1;
        gameObject.transform.GetChild(1).transform.GetComponent<Text>().text = roundNumber.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
