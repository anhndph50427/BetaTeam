using System.Collections;
using UnityEngine;

public class PushWaterSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            Debug.Log("Touch");
            Vector2 dir = ((collision.transform.position - transform.position)).normalized;
            StartCoroutine(Force(collision.gameObject , dir));
        }

        //Destroy(gameObject, 2f);
    }


    IEnumerator Force(GameObject target , Vector2 dir)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * 5, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector2.zero;    
    }
}
