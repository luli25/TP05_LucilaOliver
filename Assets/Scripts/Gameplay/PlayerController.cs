using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private PlayerConfig playerData;

    [SerializeField]
    private GroundDetector detector;

    [SerializeField]
    private Slider playerHealthBar;

    [SerializeField]
    private EnemyConfig enemyData;

    [SerializeField]
    private PlayerHealthBar healthBar;

    [SerializeField]
    private Transform respawnPoint;

    private Weapon weapon;

    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    private bool isJumping = false;

    private bool isFacingRight = true;

    private bool isTakingDamage = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        weapon = GetComponent<Weapon>();

        playerData.health = playerData.maxHealth;

    }

    void Update()
    {
        Move();
        Jump();
        Crouch();

        if(weapon.isShooting == true)
        {
            anim.Play("Shooting", 0);

        }
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

    public void TakeDamage(float damage)
    {
        playerData.health -= damage;
        healthBar.SetHealth(playerData.health);
        isTakingDamage = true;

        if(isTakingDamage == true)
        {
            anim.Play("Hurt", 0);

        }

        if(playerData.health <= 0)
        {
            Die();
            
        }
    }

    public void ResetHealth()
    {
        playerData.health = playerData.maxHealth;
        playerHealthBar.value = playerData.health;
    }

    public void ResetAnimation()
    {
        anim.Rebind();
        anim.Update(0f);
    }

    private void Die()
    {
        anim.Play("Dead", 0);
        rb.transform.position = respawnPoint.position;
    }
}