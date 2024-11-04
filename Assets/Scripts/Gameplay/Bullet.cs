using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private PlayerConfig playerConfig;

    [SerializeField]
    private GameObject bulletImpact;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = transform.right * bulletSpeed;

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Enemy"))
        {
            EnemyController enemy = hitInfo.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemy.TakeDamage(playerConfig.damage);
            }

            Instantiate(bulletImpact, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        
    }
}
