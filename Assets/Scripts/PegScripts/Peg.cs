using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class Peg : MonoBehaviour
{
    [HideInInspector] public PegType pegType = PegType.Blue;
    [HideInInspector] public int scoreOnHit = 10;

    public virtual void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PegDestroyed();
    }

    public virtual void PegDestroyed()
    {
        gameObject.SetActive(false);
        GameManager.instance.hitPegThisDrop = true;
        GameManager.instance.score += scoreOnHit;
        GameManager.instance.UpdateText();
    }
}
