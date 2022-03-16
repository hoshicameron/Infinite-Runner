using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ScoreCounter : SingletonMonoBehaviour<ScoreCounter>
{
    private int scoreCount=0;

    private float scoreCountTimerThreshold = 1.0f;
    private float scoreCountTimer;

    public bool CanCountScore { get; set; }

    private StringBuilder scoreStringBuilder=new StringBuilder();
    private void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerThreshold;
    }

    private void Update()
    {
        if(!CanCountScore)    return;

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerThreshold;
            scoreCount++;
            DisplayScore(scoreCount);

        }

    }

    private void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("m");

        UIManager.Instance.UpdateScoreText(scoreStringBuilder.ToString());
    }

    public int GetScore()
    {
        return scoreCount;
    }
}
