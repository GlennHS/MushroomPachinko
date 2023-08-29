using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegGreen : Peg
{
    //public GameObject ball;

    private GameObject newBall;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        pegType = PegType.Green;
        scoreOnHit = 10;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        newBall = Instantiate(collision.gameObject, transform.position, Quaternion.identity);
        float upForce = Random.Range(-0.5f, -2.5f);
        float sideForce = Random.Range(-2.5f, 2.5f);
        newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (upForce, sideForce), ForceMode2D.Impulse);

        base.OnCollisionEnter2D(collision);
    }
}
