using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;

    public bool isGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
