using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personLevel : MonoBehaviour
{
    public SpriteRenderer h_renderer;
    public Sprite[] sprites;
    public Color32[] colors;

    public int level = 0;

    private void Start()
    {
        h_renderer.sprite = sprites[level];
    }

    public void upgrade ()
    {
        if (level < sprites.Length - 1)
        {
            h_renderer.sprite = sprites[level + 1];
            level++;
        }

    }


}
