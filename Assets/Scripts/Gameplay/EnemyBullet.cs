using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private EnemyConfig enemyConfig;

    [SerializeField]
    private GameObject bulletImpact;

    private Rigidbody2D rb2;

    private Transform playerTransform;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if(playerTransform != null )
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb2.velocity = direction * bulletSpeed;
        }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            PlayerController player = hitInfo.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamageFromEnemy(enemyConfig.damage);
            }
        }

        Instantiate(bulletImpact, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
