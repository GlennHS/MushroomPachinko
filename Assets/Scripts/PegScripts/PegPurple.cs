using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PegPurple : Peg
{
    public int numPegsToEnable = 5;
    public bool allowPurpleResurrection = false; // Sounds like I'm trying to resurrect Prince lol

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        pegType = PegType.Purple;
        scoreOnHit = 0;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        List<GameObject> disabledPegs = GameManager.instance.pegs.Where(go => !go.activeSelf).ToList();
        if(!allowPurpleResurrection)
            disabledPegs = disabledPegs.Where(go => go.GetComponent<PegPurple>() == null).ToList();
        Debug.Log(disabledPegs.ToString());

        for(int i = 0; i < Mathf.Min(numPegsToEnable, disabledPegs.Count()); i++)
        {
            int pi = Random.Range(0, disabledPegs.Count());
            disabledPegs[pi].SetActive(true);
            disabledPegs.RemoveAt(pi);
        }

        base.OnCollisionEnter2D(collision);
    }
}
