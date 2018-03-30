using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCardDealButton : MonoBehaviour {

    private List<DrawCard> abilitycardDecks = new List<DrawCard>();
    public GameObject gridDynamic;

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
