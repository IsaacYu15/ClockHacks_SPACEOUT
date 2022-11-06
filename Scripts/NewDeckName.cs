using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDeckName : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newDeck;
    public TextMeshProUGUI inputText;

    void OnEnable()
    {
        newDeck = GameObject.Find("PackButton(Clone)");
    }

    public void done ()
    {
        foreach (Transform child in newDeck.transform)
        {
            child.GetComponent<TextMeshProUGUI>().text = inputText.text;
        }
        newDeck.name = inputText.text;
        inputText.text = null;
        gameObject.SetActive(false);

    }
}
