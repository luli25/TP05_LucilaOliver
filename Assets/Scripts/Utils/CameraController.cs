using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float damping;

    [SerializeField]
    private Transform target;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position =    Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}
