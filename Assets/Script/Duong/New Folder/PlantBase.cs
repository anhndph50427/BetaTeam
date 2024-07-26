using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    [SerializeField] protected float health;
    protected Animator animator;
    protected SpriteRenderer sr;
    protected void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        
    }
}
