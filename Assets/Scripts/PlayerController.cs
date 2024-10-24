using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        rb.velocity = new Vector2(moveInput * playerData.speed, rb.velocity.y);
        anim.SetBool("isRunning", moveInput != 0);
        playerSprite.flipX = moveInput < 0;
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
                rb.AddForce(Vector2.up * playerData.jumpControlForce * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }
}
