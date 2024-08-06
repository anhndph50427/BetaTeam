using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBasic : ZombieBase
{
    
    

    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        

        if (checkCollision == true)
        {
            
            animator.SetBool("CheckAtk", true);
        }
        else
        {
            animator.SetBool("CheckAtk", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            AudioSource.PlayOneShot(hitByBullet);
        }
    }

}
