using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
    public float health = 100f;
    public float speed = 150f;
    public float maxHealth = 100f;
    public float damage = 20f;
    public float shootingRange = 4f;
}
