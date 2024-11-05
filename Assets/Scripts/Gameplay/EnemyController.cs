using Cinemachine;
using Unity.VisualScripting;
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
    private float startTimeBtwShots;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioSource enemyDead;

    private Rigidbody2D rb2;
    private SpriteRenderer sprite;
    private bool isFacingRight = true;
    private float timeBtwShots;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyConfig.health = enemyConfig.maxHealth;


        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        // Detectar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log(distanceToPlayer);

        // Si el jugador está dentro del rango de detección
        if (distanceToPlayer <= enemyConfig.detectionRange)
        {
            // Si está fuera del rango de disparo, perseguir
            if (distanceToPlayer > enemyConfig.shootingRange)
            {
                rb2.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyConfig.speed * Time.deltaTime);
                animator.SetBool("isRunning", true);
                animator.SetBool("isShooting", false);
            }
            // Si está dentro del rango de disparo, disparar
            else if (distanceToPlayer <= enemyConfig.shootingRange)
            {
                rb2.velocity = Vector2.zero;
                animator.SetBool("isRunning", false);
                animator.SetTrigger("Shoot");
                ShootAt();
                animator.SetBool("isShooting", true);
            }
        }
        else
        {
            // Enemigo se queda quieto si el jugador está fuera del rango de detección
            rb2.velocity = Vector2.zero;
            animator.SetBool("isRunning", false);
            animator.SetBool("isShooting", false);
        }

        // Girar el enemigo si es necesario
        if ((player.position.x < transform.position.x && isFacingRight) ||
            (player.position.x > transform.position.x && !isFacingRight))
        {
            Flip();
        }

        // Llamar a la función de disparo
        
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
        enemyDead.Play();
        Destroy(gameObject, 2f);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void ShootAt()
    {
        if(timeBtwShots <= 0)
        {
            source.Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timeBtwShots = startTimeBtwShots;

        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
