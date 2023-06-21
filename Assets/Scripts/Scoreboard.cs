using TMPro;
using UnityEngine;

public class Scoreboard : UIElement<Scoreboard>
{
    [SerializeField] private int maxPoints = 11;
    [SerializeField] private TMP_Text[] scoreCounters;
    private int[] score = {0, 0};
    protected override UIState[] ValidStates { get; } =
    {
        UIState.MatchInProgress,
        UIState.Pause
    };

    private void OnEnable()
    {
        ResetScore();
    }

    private void UpdateScoreCounter(TMP_Text scoreCounter, int score)
    {
        scoreCounter.text = score.ToString();
    }

    private void ResetScore()
    {
        for (int i = 0; i < score.Length; ++i)
        {
            score[i] = 0;
            UpdateScoreCounter(scoreCounters[i], 0);
        }
    }

    public void AddPoint(int playerIndex, int numPoints = 1)
    {
        score[playerIndex] += numPoints;
        UpdateScoreCounter(scoreCounters[playerIndex], score[playerIndex]);

        if (score[playerIndex] >= maxPoints)
        {
            ResetScore();
            GameManager.Instance.EndMatch();
        }
    }
}