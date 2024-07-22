using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : PlantBase
{
    [Header("Raycast info")]
    [SerializeField] private LayerMask whatIsMask;
    [SerializeField] private float distanceLimit;

    [Header("Shoot infor")]
    [SerializeField] private GameObject bullet_prefabs;
    [SerializeField] private Transform pos_Shoot;
    [SerializeField] private float fireRate;
    private float canFire;
    void Start()
    {
        base.Start();
        canFire = 0;
        distanceLimit = Mathf.Abs(distanceLimit);
    }

    void Update()
    {
        base.Update();
        Attack();
    }

    private void Attack()
    {
        if (ZombiesDetected().collider != null)
        {
            Debug.Log("Vào vùng bắn");
            Shooting();
        }
        else
        {
            Debug.Log("Thoát khỏi vùng bắn");
        }
    }

    private void Shooting()
    {
        if (!(canFire < Time.time)) return;

        GameObject newBullet = Instantiate(bullet_prefabs , pos_Shoot.position , Quaternion.identity);
        Destroy(newBullet , 4f);
        
        canFire = Time.time + fireRate;
    }

    RaycastHit2D ZombiesDetected() => Physics2D.Raycast(transform.position, Vector2.right, distanceLimit, whatIsMask);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + distanceLimit, transform.position.y, 0));
    }
}
