using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Camera camera;

    public float damp;
    public Vector3 goal;

    public Vector2 nullVel;


    void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        goal = randomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, goal, ref nullVel, damp);

        if (Vector2.Distance (transform.position, goal) < 2f)
        {
            goal = randomPosition();
        }
    }

    public Vector3 randomPosition()
    {
        float screenX = Random.Range(0.0f, camera.pixelWidth);
        float screenY = Random.Range(0.0f, camera.pixelHeight);
        return camera.ScreenToWorldPoint(new Vector3(screenX, screenY, 0));
    }
}
