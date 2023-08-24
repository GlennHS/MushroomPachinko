using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Peg"))
        {
            GameManager.instance.bluePegsHitThisDrop++ ;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BallDestroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(
            transform.position.x < Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.min).x ||
            transform.position.x > Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.max).x
        ) { Destroy(gameObject); }
    }

    private void OnDestroy()
    {
        if(FindObjectsOfType<Ball>().Length == 0)
        {
            GameManager.instance.ballDropping = false;
            GameManager.instance.CheckGameOver();
        }
    }
}
