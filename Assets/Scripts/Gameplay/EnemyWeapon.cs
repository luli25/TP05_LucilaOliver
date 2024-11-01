using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint_e;

    [SerializeField]
    private GameObject enemyBulletPrefab;

    
    void Update()
    {
        ShootAt();
    }

    private void ShootAt()
    {
        Instantiate(enemyBulletPrefab, firePoint_e.position, firePoint_e.rotation);
    }
}
