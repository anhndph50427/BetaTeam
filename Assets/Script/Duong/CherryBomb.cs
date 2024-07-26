using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : PlantBase
{
    [SerializeField] private float delayBeforeAtk; 
    [SerializeField] private float atkDuration; 

    private bool isInAtkState = false;

    void Start()
    {
        base.Start(); 

        //if (animator != null)
        //{
        //    //animator.SetTrigger("ATK");
        //}

        StartCoroutine(ActivateAtkState());
    }

    void Update()
    {
        base.Update(); 
    }

    private IEnumerator ActivateAtkState()
    {
        yield return new WaitForSeconds(delayBeforeAtk);

        if (animator != null)
        {
            animator.SetTrigger("ATK");
        }

        isInAtkState = true;

        yield return new WaitForSeconds(atkDuration);

        Destroy(gameObject);
    }
}
