using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : PlantBase
{
    [SerializeField] private float eatDuration;
    private bool isEating = false;

    private void Start()
    {
        base.Start();
    }

    private void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Zombies") && !isEating)
        {
            StartCoroutine(EatZombie(collider.gameObject));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombies") && isEating == true)
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator EatZombie(GameObject zombie)
    {
        isEating = true;

        animator.SetTrigger("PreparingToEat");

        yield return new WaitForSeconds(0.5f);

        Destroy(zombie);

        animator.SetTrigger("Eat");

        yield return new WaitForSeconds(eatDuration);

        isEating = false;

        animator.SetTrigger("Idle");
    }
}
