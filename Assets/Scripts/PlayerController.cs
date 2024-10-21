using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float speed = 10f;

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
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
            playerSprite.flipX = false;
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isRunning", true);
            playerSprite.flipX = true;
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
