using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleType type;
    [SerializeField] private int coinValue = 10;

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
                GameManager.Instance.AddScore(coinValue);
                AudioManager.Instance.PlayCoin();
                break;

            case CollectibleType.Star:
                player.GetComponent<PlayerPowerUps>().ActivateInvincibility();
                AudioManager.Instance.PlayStar();
                break;

            case CollectibleType.ExtraLife:
                GameManager.Instance.AddLife();
                AudioManager.Instance.PlayExtraLife();
                break;
        }
    }
}