using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoreText = null;
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button QuitButton = null;

    private void Start()
    {
        string highScoreString = "HighScore: " + PlayerPrefs.GetInt(PlayerPrefsKey.BestScore.ToString(), 0);
        highscoreText.SetText(highScoreString);

        playButton.onClick.AddListener(() => SceneManager.LoadScene("Scene GamePlay"));
        QuitButton.onClick.AddListener(Application.Quit);
    }
}
