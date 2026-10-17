using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource uiSource;

    [Header("Sfx Clips")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip extraLifeClip;
    [SerializeField] private AudioClip lifeLostClip;
    [SerializeField] private AudioClip gameOverClip;

    [Header("Ui Clips")]
    [SerializeField] private AudioClip clickClip;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || (musicSource.clip == clip && musicSource.isPlaying))
            return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic() => musicSource.Stop();

    public void PlayJump() => sfxSource.PlayOneShot(jumpClip);

    public void PlayLand() => sfxSource.PlayOneShot(landClip);

    public void PlayCoin() => sfxSource.PlayOneShot(coinClip);

    public void PlayStar() => sfxSource.PlayOneShot(starClip);

    public void PlayExtraLife() => sfxSource.PlayOneShot(extraLifeClip);

    public void PlayLifeLost() => sfxSource.PlayOneShot(lifeLostClip);

    public void PlayGameOver() => sfxSource.PlayOneShot(gameOverClip);

    public void PlayClick() => uiSource.PlayOneShot(clickClip);
}