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

    private Rigidbody2D rb2;
    private SpriteRenderer sprite;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyConfig.health = enemyConfig.maxHealth;
    }

    void Update()
    {
        //rb2.velocity = Vector2.right * enemyConfig.speed;
        //animator.SetBool("isRunning", true);
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

}
