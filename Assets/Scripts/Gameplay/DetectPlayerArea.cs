using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerArea : MonoBehaviour
{
    [SerializeField]
    private float seekRadius;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private EnemyStates currentStatus;

    [SerializeField]
    private float enemySpeed;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private Vector3 initialPos;


    private enum EnemyStates
    {
        Waiting,
        Chasing,
        Returning
    }

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        switch (currentStatus)
        {
            case EnemyStates.Waiting:
                WaitingState();
                break;
            case EnemyStates.Chasing:
                break;
            case EnemyStates.Returning:
                break;
        }

    }

    private void WaitingState()
    {

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, seekRadius, playerLayer);

        if (playerCollider)
        {
            playerTransform = playerCollider.transform;
            currentStatus = EnemyStates.Waiting;
        }
    }

    private void ChasingState()
    {

    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seekRadius);
    }
}
