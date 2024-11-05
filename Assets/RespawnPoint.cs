using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject respawn;

    [SerializeField]
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawn.transform.position;
            player.ResetHealth();
            player.ResetAnimation();
        }
    }
}
