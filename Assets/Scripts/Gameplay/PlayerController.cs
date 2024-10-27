using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private PlayerConfig playerData;

    [SerializeField]
    private GroundDetector detector;

    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    private bool isJumping = false;

    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    private void Move()
    {
        float moveInput = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        rb.velocity = new Vector2(moveInput * playerData.speed, rb.velocity.y);
        anim.SetBool("isRunning", moveInput != 0);

        if(moveInput > 0 && !isFacingRight)
        {
            Flip();

        } else if(moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }


    private void Jump()
    {
        if (detector.isGrounded)
        {
            isJumping = false;

            if (Input.GetKey(KeyCode.Space))
            {
                isJumping = true;
                detector.isGrounded = false;
                anim.SetTrigger("onJump");
                rb.AddForce(Vector2.up * playerData.jumpForce, ForceMode2D.Impulse);
            }
        }

        if (isJumping && Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector2.up * playerData.jumpControlForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }

    private void Crouch()
    {
        if (detector.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("isCrouching", true);

            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("isCrouching", false);
            }
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}