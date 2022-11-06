using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void LoadNextScene (string name)
    {
        SceneManager.LoadScene(name);

    }

    public GameObject active;
    public GameObject d_active;

    public void SwitchActive ()
    {
        active.SetActive(true);
        d_active.SetActive(false);
    }
}
