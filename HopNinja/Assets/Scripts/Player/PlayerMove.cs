using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;
    
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public bool flipx = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level0");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            flipx = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            flipx = true;
        }
        else 
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }


        if ((Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w")) && CheckGround.isGrounded) 
        {
            jump(jumpSpeed);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true) ;
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space") && !Input.GetKey("up") && !Input.GetKey("w"))
            {
                rb2D.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }



    }

    public void jump(float jump)
    {
        rb2D.velocity = new Vector2(rb2D.velocity.y, jump);
        animator.SetBool("Run", false);
    }

}
     