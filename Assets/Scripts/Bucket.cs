using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float speed = 3f;

    private bool goingLeft;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private void Start()
    {
        goingLeft = false;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;

        if(goingLeft )
            newPos.x -= speed * Time.deltaTime;
        else
            newPos.x += speed * Time.deltaTime;
        rb.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            if(GameManager.instance.bluePegsHitThisDrop > 0)
                GameManager.instance.score += 20;
            GameManager.instance.ballsRemaining++;
            GameManager.instance.UpdateText();
            audioSource.Play();
        }
        else if(collision.gameObject.CompareTag("SceneEdge"))
        {
            goingLeft = !goingLeft;
        }
    }
}
