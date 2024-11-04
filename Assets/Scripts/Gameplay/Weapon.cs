using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private AudioSource bulletSound;

    public bool isShooting;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            Shoot();

        }
        else if (Input.GetMouseButtonUp(0))
        {

            isShooting = false;
        }
    }

    private void Shoot()
    {
        bulletSound.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
