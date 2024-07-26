using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBasic : ZombieBase
{
    void Start()
    {
        base.Start();
    }


    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Plants"))
        {
            Explode();
            TriggerDeathAnimation();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }

    private void TriggerDeathAnimation()
    {
        animator.SetTrigger("Death");
    }
}
