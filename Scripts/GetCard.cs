using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetCard : MonoBehaviour
{
    public static string[] cardFront = new string [] {
    };
    public static string[] cardBack = new string[] { 
    };

    public CardInDeck referencedDeck;

    public TMP_InputField front;
    public TMP_InputField back;

    public void Start()
    {
        front.textComponent.enableWordWrapping = true;
        back.textComponent.enableWordWrapping = true;

        cardFront = referencedDeck.cardFront;
        cardBack = referencedDeck.cardBack;
    }

    public void GetCardData ()
    {
        if (front.text != null && back.text != null)
        {
            System.Array.Resize(ref cardFront, cardFront.Length + 1);
            System.Array.Resize(ref cardBack, cardBack.Length + 1);

            cardFront[cardFront.Length - 1] = front.text;
            cardBack[cardBack.Length - 1] = back.text;

            referencedDeck.cardFront = cardFront;
            referencedDeck.cardBack = cardFront;

            front.text = " ";
            back.text = " ";
        }

        
    }
}
