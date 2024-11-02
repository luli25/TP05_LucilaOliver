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

    [SerializeField]
    private float distance;

    private Rigidbody2D rb2;
    private SpriteRenderer sprite;

    public Vector3 initalPos;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyConfig.health = enemyConfig.maxHealth;
        initalPos = transform.position;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("distance", distance);

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

    public void Flip(Vector3 target)
    {
        if(transform.position.x < target.x)
        {
            sprite.flipX = true;

        } else {

            sprite.flipX = false;
        }
    }

    private void Die()
    {
        animator.Play("Dead", 0);
        Destroy(gameObject, 2f);
    }

}
