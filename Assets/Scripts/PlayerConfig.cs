using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerConfig", order = 1)]
public class PlayerConfig : ScriptableObject
{
    public float speed = 150f;
    public float health = 100f;
    public int lives = 3;
    public float jumpForce = 5f;
    public float jumpControlForce = 5f;

}


