using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInDeck : MonoBehaviour
{
    public string[] cardFront = new string[] {

    };
    public string[] cardBack = new string[] {

    };

    public GameObject editCard;
    public GameObject editCardManager;

    public void SelectedDeck ()
    {
        GameObject samp = GameObject.Find("HealthSample");
        editCard = samp.GetComponent<CardInDeck>().editCard;
        editCardManager = samp.GetComponent<CardInDeck>().editCardManager;

        GetCard card = editCard.GetComponent<GetCard>();
        card.referencedDeck = this;

        editCardManager.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);


    }
}
