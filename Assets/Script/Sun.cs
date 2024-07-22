using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float stopPos { get; set; }
    [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= stopPos)
        {
            transform.position -= new Vector3(0,speed * Time.deltaTime, 0);
        }
    }
}
