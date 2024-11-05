using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Referencia al jugador

    [SerializeField]
    private float detectionRange = 10f; // Distancia en la que el enemigo detecta al jugador

    [SerializeField]
    private EnemyConfig enemyConfig;

    [SerializeField]    
    private float WaittingTimeBtwShots = 2f; // Tiempo de espera antes de disparar

    [SerializeField]
    private GameObject proyectilePrebaf; // Referencia al proyectil que el enemigo dispara

    [SerializeField]
    private Transform firePoint; // Punto de disparo del enemigo

    private bool isChasing = false;
    private bool canShoot = false;

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();

            if (canShoot)
            {
                Shoot();
            }
        }
        else
        {
            DetectPlayer();
        }
    }

    // Detecta al jugador si está dentro del rango de detección
    private void DetectPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRange)
        {
            isChasing = true;
            StartCoroutine(WaitingTimeBeforeShots());
        }
    }

    // Hace que el enemigo siga al jugador
    private void ChasePlayer()
    {
        // Movimiento hacia el jugador
        Vector3 direccion = (player.position - transform.position).normalized;
        transform.position += direccion * enemyConfig.speed * Time.deltaTime;

        // Hacer que el enemigo mire al jugador
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 5f);
    }

    // Espera unos segundos antes de comenzar a disparar
    private IEnumerator WaitingTimeBeforeShots()
    {
        yield return new WaitForSeconds(WaittingTimeBtwShots);
        canShoot = true;
    }

    // Método para disparar
    private void Shoot()
    {
        // Instanciar el proyectil en el punto de disparo
        if (proyectilePrebaf != null)
        {
            Instantiate(proyectilePrebaf, firePoint.position, firePoint.rotation);
        }
    }
}
