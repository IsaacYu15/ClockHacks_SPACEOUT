using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    public GameObject renameDeck;
    public GameObject card;
    public GameObject packManager;

    public void AddNewCard ()
    {
        GameObject go = Instantiate (card, transform);
        Vector3 scale = go.transform.localScale;
        go.transform.SetParent (packManager.transform);
        go.transform.localScale = scale;

        int childCount = 0;

        foreach (Transform child in transform)
        {
            childCount++;
        }

        go.transform.SetSiblingIndex(childCount - 1);


        packManager.GetComponent<ScrollButtons>().updateList();

        renameDeck.SetActive(true);
    }
}
