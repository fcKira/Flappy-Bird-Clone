using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenCountdown : ScreenUI
{
    [SerializeField] TextMeshProUGUI _timerText;

    [SerializeField] float _startCountdownTime;
    float _currentTime;

    public override void Activate()
    {
        _currentTime = _startCountdownTime;

        base.Activate();
    }

    /// <summary>
    /// Triggered from Pause Button
    /// </summary>
    public void PauseGame()
    {
        //_pauseButton.SetActive(false);

        GameManager.Instance.PauseGameplay();
    }

    void Update()
    {
        _timerText.text = Mathf.CeilToInt(_currentTime).ToString();

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            GameManager.Instance.GoToGameplay();
        }
    }
}
