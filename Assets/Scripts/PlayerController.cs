using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private PlayerConfig playerData;

    private Rigidbody2D rb;

    private SpriteRenderer playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
            playerSprite.flipX = false;
            rb.velocity = Vector2.right * playerData.speed * Time.deltaTime;

        } else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isRunning", true);
            playerSprite.flipX = true;
            rb.velocity = Vector2.left * playerData.speed * Time.deltaTime;

        } else
        {
            anim.SetBool("isRunning", false);
        }
 
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("onJump");
            rb.AddForce(Vector2.up * playerData.jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
