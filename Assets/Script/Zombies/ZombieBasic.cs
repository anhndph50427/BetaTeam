using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBasic : ZombieBase
{
    public AudioClip hitByBullet;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            AudioSource.PlayOneShot(hitByBullet);
        }
    }

}
