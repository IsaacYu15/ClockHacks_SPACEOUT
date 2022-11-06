using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButtons : MonoBehaviour
{
    public float scrollSpeed = 2f;

    Vector3 offset = Vector3.zero;
    Vector3 nullVel = Vector3.zero;

    public Transform[] objects;

    private void Start()
    {
        updateList();
    }

    public void updateList()
    {
        int i = 0;

        foreach (Transform child in transform)
        {
            System.Array.Resize(ref objects, i + 1);

            objects[i] = child;
            i++;
        }
    }
    void Update()
    {
        if (Input.mouseScrollDelta.y == 0)
        {
            //little bit of smoothing
            offset = Vector3.SmoothDamp(offset / 1.3f, Vector3.zero, ref nullVel, 1f);
        } else
        {
            float dir = Input.mouseScrollDelta.y;
            offset.y = dir * scrollSpeed;
            Debug.Log(dir);

            //set some constraints for the scroll features
            if (objects[0].position.y > 150 && dir < 0)
            {
                transform.position += offset;
            }
            else if (objects[objects.Length - 1].position.y < 150 && dir > 0)
            {
                transform.position += offset;
            }
        }
       
        
    }
}
