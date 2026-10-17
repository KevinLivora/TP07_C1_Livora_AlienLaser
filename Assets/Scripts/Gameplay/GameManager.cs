using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private GameplayHud hud;

    [Header("World Speed")]
    [SerializeField] private float initialSpeed = 7f;
    [SerializeField] private float maxSpeed = 16f;
    [SerializeField] private float acceleration = 0.1f;

    [Header("Lives")]
    [SerializeField] private int startingLives = 0;
    [SerializeField] private int maxLives = 3;

    private const string BestScoreKey = "BestScore";

    private float score;
    private int lastShownScore = -1;
    private int lives;

    public bool IsPlaying { get; private set; }
    public float WorldSpeed { get; private set; }

    private void Awake()
    {
        Instance = this;
        IsPlaying = true;
        WorldSpeed = initialSpeed;
        lives = startingLives;
        hud.SetLives(lives);
    }

    private void Update()
    {
        if (!IsPlaying)
            return;

        WorldSpeed = Mathf.Min(WorldSpeed + acceleration * Time.deltaTime, maxSpeed);
        score += WorldSpeed * Time.deltaTime;

        int currentScore = Mathf.FloorToInt(score);
        if (currentScore == lastShownScore)
            return;

        lastShownScore = currentScore;
        hud.SetScore(currentScore);
    }

    public void AddScore(float amount)
    {
        if (!IsPlaying)
            return;

        score += amount;
    }

    public void AddLife()
    {
        if (!IsPlaying)
            return;

        lives = Mathf.Clamp(lives + 1, 0, maxLives);
        hud.SetLives(lives);
    }

    public void HandlePlayerHit(PlayerPowerUps playerPowerUps)
    {
        if (!IsPlaying)
            return;

        if (lives > 0)
        {
            lives--;
            hud.SetLives(lives);
            playerPowerUps.ActivateInvincibility();
            AudioManager.Instance.PlayLifeLost();
            return;
        }

        EndGame();
    }

    private void EndGame()
    {
        IsPlaying = false;

        int finalScore = Mathf.FloorToInt(score);
        int bestScore = Mathf.Max(PlayerPrefs.GetInt(BestScoreKey, 0), finalScore);
        PlayerPrefs.SetInt(BestScoreKey, bestScore);
        PlayerPrefs.Save();

        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayGameOver();

        hud.ShowGameOver(finalScore, bestScore);
    }
}