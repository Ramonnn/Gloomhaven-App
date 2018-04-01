using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCardDealButton : MonoBehaviour {

    private List<DrawCard> abilitycardDecks = new List<DrawCard>();
    public GameObject gridDynamic;

    void OnEnable()
    {
        RoundTracker.TrackingRound += ReEnableCardDealButton;
    }

    void OnDestroy() //Because this button does get disabled and gets enabled by the same event. (which it won't listen to anymore if disabled).
    {
        RoundTracker.TrackingRound -= ReEnableCardDealButton;
    }

    public void DealCards()
    {
        abilitycardDecks.Clear();
        for (int i = 0; i < gridDynamic.transform.childCount; i++)
        {
            abilitycardDecks.Add(gridDynamic.transform.GetChild(i).GetComponentInChildren<DrawCard>());
        }
        gameObject.SetActive(false);
        foreach (DrawCard deck in abilitycardDecks)
        {
            deck.DrawACard();
        }
    }

    public void ReEnableCardDealButton()
    {
        gameObject.SetActive(true);
        foreach (DrawCard deck in abilitycardDecks)
        {
            deck.RefreshDeck();
        }
    }


}
