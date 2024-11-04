using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private GameObject bulletImpact;

    private Rigidbody2D rb2;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2.transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
