using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreHandler : MonoBehaviour
{
    public int Highscore { get; private set; }
    public int Currentscore { get; private set; }

    Action<int> _OnUpdateCurrentscore;
    Action<int> _OnUpdateHighscore;

    public ScoreHandler(Action<int> updateHighscoreMethod, Action<int> updateCurrentscoreMethod)
    {
        Highscore = PlayerPrefs.GetInt("Highscore");
        Currentscore = 0;

        _OnUpdateHighscore = updateHighscoreMethod;
        _OnUpdateCurrentscore = updateCurrentscoreMethod;

        _OnUpdateHighscore(Highscore);
        _OnUpdateCurrentscore(Currentscore);
    }

    public void ResetCurrentScore()
    {
        Currentscore = 0;
    }

    public void EndGameSession()
    {
        PlayerPrefs.SetInt("Highscore", Highscore);
    }

    public void EarnScore()
    {
        Currentscore++;
        _OnUpdateCurrentscore(Currentscore);

        if (Currentscore > Highscore)
        {
            Highscore = Currentscore;
            _OnUpdateHighscore(Highscore);
        }
    }
}
