using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    private int maxPoints = 2;
    private int[] score = {0, 0};
    [SerializeField] private TMP_Text[] scoreCounters;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void AddPoint(int playerIndex, int numPoints = 1)
    {
        score[playerIndex] += numPoints;
        UpdateScoreCounter(scoreCounters[playerIndex], score[playerIndex]);

        if (score[playerIndex] >= maxPoints)
        {
            ResetScore();
            gameManager.EndGame(playerIndex);
        }
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
}
