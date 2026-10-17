using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerDataSo : ScriptableObject
{
    public float moveSpeed = 6f;
    public float jumpForce = 15f;
    public float gravityScale = 4f;
    public KeyCode jumpKey = KeyCode.Space;
    public float invincibilityDuration = 5f;
}
