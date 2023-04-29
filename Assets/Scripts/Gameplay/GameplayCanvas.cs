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

    private void StartInitialize()
    {
        _highscoreText.gameObject.SetActive(false);
        _currentScoreText.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(false);
    }

    public void GameplayInitialize()
    {
        _highscoreText.gameObject.SetActive(true);
        _currentScoreText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Triggered from Pause Button
    /// </summary>
    public void PauseGame()
    {
        _pauseButton.SetActive(false);

        GameManager.Instance.PauseGameplay();
    }

    public void UnpauseGame()
    {
        _pauseButton.SetActive(true);
    }
}
