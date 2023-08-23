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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        GameManager.instance.ballDropping = false;
        GameManager.instance.UpdateText();
        GameManager.instance.CheckGameOver();
    }
}
