using UnityEngine;

public class test : MonoBehaviour
{
    public int frameRate = 24;
    public float speed = 100f;

    private Vector2 target;

    public Transform player;
    public Vector3 direction;

    //private void Awake()
    //{
    //    Application.targetFrameRate = frameRate;
    //}

    //void FixedUpdate()
    //{
    //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector2 movement = target - (Vector2)transform.position;
    //    movement.Normalize();

    //    transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    //}

    private void Update()
    {
        direction = player.position - transform.position;
        direction.Normalize();

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction,Vector3.left);
            transform.rotation = toRotation;
        }
    }
}