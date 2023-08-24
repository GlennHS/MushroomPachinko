using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PegOrange : Peg
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        pegType = PegType.Orange;
        scoreOnHit = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        GameManager.instance.bouncinessIncreaseFromOrange += 0.5f;

        float temporaryBounciness = collision.gameObject.GetComponent<Rigidbody2D>().sharedMaterial.bounciness + GameManager.instance.bouncinessIncreaseFromOrange;
        PhysicsMaterial2D temporaryMaterial = new PhysicsMaterial2D("TemporaryMaterial");
        temporaryMaterial.bounciness = temporaryBounciness;

        // Apply temporary material with increased bounciness
        ballRb.sharedMaterial = temporaryMaterial;

        base.OnCollisionEnter2D(collision);
    }
}
