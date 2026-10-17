using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Color invincibleColor = new Color(1f, 0.9f, 0.3f);

    private SpriteRenderer spriteRenderer;
    private float invincibleTimer;

    public bool IsInvincible => invincibleTimer > 0f;
    public float InvincibleTimer => invincibleTimer;
    public float InvincibleDuration => data.invincibilityDuration;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!IsInvincible)
            return;

        invincibleTimer -= Time.deltaTime;

        if (!IsInvincible)
            spriteRenderer.color = Color.white;
    }

    public void ActivateInvincibility()
    {
        invincibleTimer = data.invincibilityDuration;
        spriteRenderer.color = invincibleColor;
    }
}
