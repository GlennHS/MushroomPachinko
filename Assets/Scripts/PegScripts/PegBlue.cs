using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegBlue : Peg
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        pegType = PegType.Blue;
        scoreOnHit = 5;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        scoreOnHit = 5 * GameManager.instance.bluePegsHitThisDrop;

        base.OnCollisionEnter2D(collision);
    }
}
