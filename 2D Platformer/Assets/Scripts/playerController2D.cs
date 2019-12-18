using UnityEngine;

public class playerController2D : MonoBehaviour
{

    Animator animator;

    Rigidbody2D rb2d;

    SpriteRenderer spriteRenderer;

   [SerializeField]
    private float walkSpeed = 6;

    [SerializeField]
    private float jumpHeight = 5;

    public Transform groundCheck;
    public Transform groundCheck_L;
    public Transform groundCheck_R;

    bool isGrounded;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
           (Physics2D.Linecast(transform.position, groundCheck_L.position, 1 << LayerMask.NameToLayer("Ground")))||
           (Physics2D.Linecast(transform.position, groundCheck_R.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;
        
        } else {
            
            isGrounded = false;
            animator.Play("Player_jump");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(walkSpeed, rb2d.velocity.y);

            if (isGrounded == true)
            {
                animator.Play("Player_walk");
            }

            spriteRenderer.flipX = false;

        } else if (Input.GetKey("a") || Input.GetKey("left")) {

            rb2d.velocity = new Vector2(-walkSpeed, rb2d.velocity.y);

            if (isGrounded == true)
            {
                animator.Play("Player_walk");
            }

            spriteRenderer.flipX = true;

        } else {
            if (isGrounded == true)
            {
                animator.Play("Player_idle");
            }

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            animator.Play("Player_jump");
        }

        

    }
}
