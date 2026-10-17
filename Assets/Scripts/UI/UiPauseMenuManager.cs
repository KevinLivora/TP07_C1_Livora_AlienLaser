using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPauseMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnPauseSettings;
    [SerializeField] private Button btnPauseCredits;
    [SerializeField] private Button btnPauseQuit;

    [Header("Back Buttons")]
    [SerializeField] private Button btnBackSettings;
    [SerializeField] private Button btnBackCredits;

    private bool isPaused = false;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnPauseSettings.onClick.AddListener(() => OpenPanel(settingsPanel));
        btnPauseCredits.onClick.AddListener(() => OpenPanel(creditsPanel));
        btnPauseQuit.onClick.AddListener(OnQuitClicked);

        btnBackSettings.onClick.AddListener(CloseToPauseMenu);
        btnBackCredits.onClick.AddListener(CloseToPauseMenu);
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnPauseSettings.onClick.RemoveAllListeners();
        btnPauseCredits.onClick.RemoveAllListeners();
        btnPauseQuit.onClick.RemoveAllListeners();
        btnBackSettings.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();
    }

    private void OnQuitClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


    private void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void OnContinueClicked()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OpenPanel(GameObject panelToOpen)
    {
        pausePanel.SetActive(false);
        panelToOpen.SetActive(true);
    }

    private void CloseToPauseMenu()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
