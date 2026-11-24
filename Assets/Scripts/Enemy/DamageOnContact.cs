using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        // Warning: OnTriggerStay2D corre en cada paso de física y hace GetComponent cada vez mientras el jugador está adentro.
        // Usá other.TryGetComponent(out PlayerHealth health) o cacheá la referencia en OnTriggerEnter2D.
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
            health.TakeDamage(damage);
    }
}
