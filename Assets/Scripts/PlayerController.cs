using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedRun = 10f;
    public float jump = 20f;
    public float directMove;
    public bool isRight = true;
    public bool isGrounded;
    public float ckGroundRadius = 0.2f;

    public LayerMask layerGround;
    public Transform ckGround;
    private Rigidbody2D rb;
    private Animator animator;

    float health = 1000000f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isRight = true;
    }

    private void FixedUpdate()
    {
        CheckGround();
        rb.velocity = new Vector2(speedRun * directMove, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        directMove = Input.GetAxisRaw("Horizontal");
        CheckHuongXoay();

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    private void CheckHuongXoay()
    {
        if (isRight && directMove < 0 || !isRight && directMove > 0)
        {
            isRight = !isRight;

            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(ckGround.position, ckGroundRadius, layerGround);
        if (collider.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Chạm rồi");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("mất 1 máu rồi");
            health -= 1 * Time.fixedDeltaTime;
            print(health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("không mất máu nữa");
        }
    }
}