using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [Header("InGameUI")]
    [SerializeField] private Button pauseButton = null;
    [SerializeField] private GameObject pauseMenuGameObject = null;
    [SerializeField] private GameObject[] healthBars = null;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Pause UI")]
    [SerializeField] private Button puseMenu_ExitButton = null;
    [SerializeField] private Button puseMenu_ResumeButton = null;
    [SerializeField] private Button puseMenu_RestartButton = null;

    [Header("Game Over UI")]
    [SerializeField] private Button gameOverMenu_ExitButton = null;
    [SerializeField] private Button gameOverMenu_RestartButton = null;
    [SerializeField] private GameObject gameOverGameObject = null;
    [SerializeField] private TextMeshProUGUI currentScoreText = null;
    [SerializeField] private TextMeshProUGUI bestScoreText = null;


    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);

        puseMenu_ExitButton.onClick.AddListener(ExitGame);
        puseMenu_ResumeButton.onClick.AddListener(ResumeGame);
        puseMenu_RestartButton.onClick.AddListener(RestartGame);

        gameOverMenu_ExitButton.onClick.AddListener(ExitGame);
        gameOverMenu_RestartButton.onClick.AddListener(RestartGame);
    }

    private void ResumeGame()
    {
        // Unpause Game and hide pause menu
        Time.timeScale = 1;
        pauseMenuGameObject.SetActive(false);
    }

    private void PauseGame()
    {
        // Pause Game and show pause menu
        Time.timeScale = 0;
        pauseMenuGameObject.SetActive(true);
    }

    private static void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private static void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene_MainMenu");
    }

    public int HealthBarsLength()
    {
        return healthBars.Length;
    }

    public GameObject[] HealthBars
    {
        get { return healthBars; }
        set { healthBars = value; }
    }

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverGameObject.SetActive(true);

        currentScoreText.SetText(ScoreCounter.Instance.GetScore().ToString());
        bestScoreText.SetText(PlayerPrefs.GetInt(PlayerPrefsKey.BestScore.ToString()).ToString(),0);
    }

    public void UpdateScoreText(string text)
    {
        scoreText.SetText(text);
    }
}
