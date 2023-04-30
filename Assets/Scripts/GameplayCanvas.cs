using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] GameObject _pauseButton;
    [SerializeField] TextMeshProUGUI _highscoreText;
    [SerializeField] TextMeshProUGUI _currentScoreText;

    private void Awake()
    {
        StartInitialize();
    }

    public void SetCurrentScore(int score)
    {
        _currentScoreText.text = score.ToString();
    }

    public void SetHighscore(int score)
    {
        _highscoreText.text = score.ToString();
    }

    public void StartInitialize()
    {
        _highscoreText.gameObject.SetActive(true);
        _currentScoreText.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(false);
    }

    public void HideAllScores()
    {
        _highscoreText.gameObject.SetActive(false);
        _currentScoreText.gameObject.SetActive(false);
        _pauseButton.SetActive(false);
    }

    public void GameplayInitialize()
    {
        _currentScoreText.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
    }


    public void BTN_PauseGame()
    {
        _pauseButton.SetActive(false);

        GameManager.Instance.PauseGameplay();
    }

    public void UnpauseGame()
    {
        _pauseButton.SetActive(true);
    }
}
