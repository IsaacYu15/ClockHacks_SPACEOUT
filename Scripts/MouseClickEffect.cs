using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEffect : MonoBehaviour
{
    public AudioClip click;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp (0))
        {
            AudioSource.PlayClipAtPoint(click, transform.position);
        }

    }
}
