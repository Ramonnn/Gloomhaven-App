using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTracker : MonoBehaviour {


    public delegate void RoundProperties();
    public static event RoundProperties UpdateInitiativeOrder;
    public static event RoundProperties TrackingRound;
    public Button cardDealButton, roundButton;

    public void InitiativeUpdater() // execute this method on nextround click.
    {
        if (UpdateInitiativeOrder != null)
        {
            UpdateInitiativeOrder();
        }
        cardDealButton.interactable = false;
    }

    public void RoundTrackerClick()
    {
        if (TrackingRound != null)
        {
            TrackingRound();
        }
    }

    void OnEnable()
    {
        TrackingRound += UpdateRoundNumber;
    }

    void OnDisable()
    {
        TrackingRound -= UpdateRoundNumber;
    }

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
        cardDealButton.interactable = true;
        roundButton.interactable = false;

    }
}
