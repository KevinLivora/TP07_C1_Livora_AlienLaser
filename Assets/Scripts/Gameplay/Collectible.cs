using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        Collect(other);
        Destroy(gameObject);
    }

    private void Collect(Collider2D player)
    {
        switch (type)
        {
            case CollectibleType.Coin:
                AudioManager.Instance.PlayCoin();
                break;

            case CollectibleType.Star:
                // Suggestion: GetComponent<PlayerPowerUps>() sin null check y repetido en dos cases.
                // Resolvelo una sola vez con player.TryGetComponent(out PlayerPowerUps powerUps) antes del switch.
                player.GetComponent<PlayerPowerUps>().ActivateInvincibility();
                AudioManager.Instance.PlayStar();
                break;

            case CollectibleType.ExtraLife:
                GameManager.Instance.AddLife();
                AudioManager.Instance.PlayExtraLife();
                break;

            case CollectibleType.PowerShot:
                player.GetComponent<PlayerPowerUps>().ActivatePowerShot();
                AudioManager.Instance.PlayStar();
                break;

            case CollectibleType.Key:
                GameManager.Instance.AddKey();
                break;
        }
    }
}
