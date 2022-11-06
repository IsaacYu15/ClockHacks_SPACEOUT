using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByPlayer : MonoBehaviour
{
    public AudioClip magic;
    public Rigidbody2D rb;
    public Camera camera;

    public Vector2 mousePos;
    public Wander wander;
    public ParticleSystem poof;

    bool isDragging = false;


    public void Start()
    {
        camera = wander.camera;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<moveByPlayer>().isDragging && Input.GetMouseButton(0) &&
            gameObject.GetComponent<personLevel>().level == collision.gameObject.GetComponent<personLevel>().level)
        {
            ParticleSystem p = Instantiate(poof, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<personLevel>().upgrade();

            AudioSource.PlayClipAtPoint(magic, transform.position);

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        wander.enabled = false;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (isDragging)
        {
            transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        StartCoroutine(enableWander());
    }

    IEnumerator enableWander ()
    {
        yield return new WaitForSeconds(0.75f);
        wander.enabled = true;
    }
}

