using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAudio : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        player.Jumped += OnJumped;
        player.Landed += OnLanded;
    }

    private void OnDisable()
    {
        player.Jumped -= OnJumped;
        player.Landed -= OnLanded;
    }

    private void OnJumped() => AudioManager.Instance.PlayJump();

    private void OnLanded() => AudioManager.Instance.PlayLand();
}
