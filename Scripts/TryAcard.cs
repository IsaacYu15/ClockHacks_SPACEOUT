using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAcard : MonoBehaviour
{
    public GameObject testCard;

    public void Try ()
    {
        gameObject.SetActive(false);
        testCard.SetActive(true);

    }
}
