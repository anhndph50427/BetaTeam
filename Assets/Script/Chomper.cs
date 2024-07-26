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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombies") && !isEating)
        {
            StartCoroutine(EatZombie(collision.gameObject));
        }
    }

    private IEnumerator EatZombie(GameObject zombie)
    {
        animator.SetTrigger("PreparingToEat");

        yield return new WaitForSeconds(0.5f);

        Destroy(zombie);

        animator.SetTrigger("Eat");

        isEating = true;

        yield return new WaitForSeconds(eatDuration);

        isEating = false;
    }
}
