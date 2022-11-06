using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSounds : MonoBehaviour
{
    public static BgSounds sounds;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (sounds == null)
        {
            sounds = this;
        } else
        {
            Destroy(gameObject);
        }

    }

}
