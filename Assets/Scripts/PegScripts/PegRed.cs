using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegRed : Peg
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        pegType = PegType.Red;
        scoreOnHit = 50;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.bluePegsHitThisDrop++;
        base.OnCollisionEnter2D(collision);
    }
}
