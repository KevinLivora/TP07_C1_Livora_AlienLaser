using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]
public class EnemyDataSo : ScriptableObject
{
    // Warning: Los campos del SO son public y cualquier script puede modificarlos en runtime (y el cambio persiste en el .asset dentro del editor).
    // Pasalos a [SerializeField] private y exponé properties de solo lectura, por ejemplo public float MaxHealth => maxHealth;
    public float maxHealth = 100f;
    public float moveSpeed = 1.5f;
    public float patrolDistance = 3f;
}
