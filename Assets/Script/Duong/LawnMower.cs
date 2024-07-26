using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour
{
    public float speed;
    private bool isActivated = false;

    private void Update()
    {
        if (isActivated)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombies"))
        {
            isActivated = true;
            Destroy(collision.gameObject);
            Destroy(gameObject,4f);
        }
    }
}
