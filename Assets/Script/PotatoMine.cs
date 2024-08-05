using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : PlantBase
{
    public float sproutTime = 10f;
    private bool isSprouted = false;

    private void Start()
    {
        base.Start();
        Invoke("Sprout", sproutTime);
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Sprout()
    {
        isSprouted = true;
        animator.SetBool("TroiLen", true);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Zombies") && isSprouted)
        {
            animator.SetTrigger("ATK");
            Destroy(gameObject, 1f);
        }
        if (collider.CompareTag("Zombies") && collider.GetComponent<CircleCollider2D>().enabled)
        {
            TakeDamage(100);
        }
    }
}
