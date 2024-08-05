using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : PlantBase
{
    [SerializeField] private float eatDuration = 10f;
    private bool isEating = false;

    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Zombies"))
        {
            // Nếu đang ăn, không thực hiện thêm hành động
            if (!isEating)
            {
                StartCoroutine(EatZombie(collider.gameObject));
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

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Zombies") && collider.GetComponent<CircleCollider2D>().enabled)
        {
            TakeDamage(100);
        }
    }
}