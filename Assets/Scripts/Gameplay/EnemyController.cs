using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private EnemyConfig enemyConfig;

    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private Transform player;

    private Rigidbody2D rb2;
    private SpriteRenderer sprite;
    private bool isFacingRight = true;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyConfig.health = enemyConfig.maxHealth;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > enemyConfig.shootingRange)
        {
            rb2.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyConfig.speed * Time.deltaTime);
            animator.SetBool("isRunning", true);

        } else if(Vector2.Distance(transform.position, player.position) <= enemyConfig.shootingRange)
        {
            rb2.velocity = Vector2.zero;
            animator.SetBool("isRunning", false);
            animator.SetTrigger("Shoot");

        } else if(Vector2.Distance(transform.position, player.position) > enemyConfig.shootingRange)
        {
            rb2.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyConfig.speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            animator.SetTrigger("Chase");
        }

        if ((player.position.x < transform.position.x && isFacingRight) ||
            (player.position.x > transform.position.x && !isFacingRight))
        {
            Flip();
        }
    }

    public void TakeDamage(float damage)
    {
        enemyConfig.health -= damage;
        healthSlider.value = enemyConfig.health;

        healthBar.UpdateHealthBar(enemyConfig.health, enemyConfig.maxHealth);

        if (enemyConfig.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.Play("Dead", 0);
        Destroy(gameObject, 2f);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        sprite.flipX = !sprite.flipX;
    }

}
