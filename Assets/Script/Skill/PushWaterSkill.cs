using System.Collections;
using UnityEngine;

public class PushWaterSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            Vector2 dir = ((collision.transform.position - transform.position)).normalized;
            StartCoroutine(Force(collision.gameObject , dir));
        }
    }


    IEnumerator Force(GameObject target , Vector2 dir)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.AddForce(dir , ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector2.zero;    
    }
}
