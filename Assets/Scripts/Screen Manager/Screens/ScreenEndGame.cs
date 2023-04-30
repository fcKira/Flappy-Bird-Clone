using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenEndGame : ScreenUI
{
    [SerializeField] float _timeToShowScore;
    [SerializeField] TextMeshProUGUI _highscoreText;
    [SerializeField] TextMeshProUGUI _currentScoreText;

    int _currentScore;

    public override void Activate()
    {
        base.Activate();

        _currentScore = GameManager.Instance.Currentscore;
        _highscoreText.text = GameManager.Instance.Highscore.ToString();

        StartCoroutine(ShowCurrentScoreInTime());
    }

    public void BTN_Ok()
    {
        StopAllCoroutines();
        GameManager.Instance.GoToMainMenu();
    }

    IEnumerator ShowCurrentScoreInTime()
    {
        float ticks = 0;

        while (ticks <= _timeToShowScore)
        {
            ticks += Time.deltaTime;
            _currentScoreText.text = Mathf.RoundToInt(Mathf.Lerp(0, _currentScore, ticks / _timeToShowScore)).ToString();
            yield return null;
        }

    }
}
