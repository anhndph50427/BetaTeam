using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : MonoBehaviour
{
    public Animator animator;
    public float sproutTime = 5f;
    private bool isSprouted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("Sprout", sproutTime); // Gọi hàm Sprout sau 5 giây
    }

    void Sprout()
    {
        isSprouted = true;
        animator.SetBool("TroiLen", true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Zombie") && isSprouted)
        {
            animator.SetTrigger("ATK");
            Destroy(gameObject, 1f);
        }
    }
}
