using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    protected Animator animator;
    protected SpriteRenderer sr;

    protected bool canMove = false;
    
    protected void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    protected void startMove()
    {
        canMove = true;
    }
    protected void stopMove()
    {
        canMove = false;
    }
    protected void Update()
    {
        if (canMove == true)
        {
            moving(speed);
        }
    }

    protected void moving(float x)
    {
        transform.Translate(Vector2.left * x * Time.deltaTime);
    }

    public void takeDame(float dame)
    {
        health -= dame;
        StartCoroutine(flashFx());
    }

    IEnumerator flashFx()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1, 1);

    }
}
