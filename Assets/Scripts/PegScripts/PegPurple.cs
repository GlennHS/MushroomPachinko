using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegPurple : Peg
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        pegType = PegType.Purple;
        scoreOnHit = 20;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
