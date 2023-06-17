using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    private int maxPoints = 2;
    private int[] score = {0, 0};
    [SerializeField] private TMP_Text[] scoreCounters;

    public void AddPoint(int playerIndex, int numPoints = 1)
    {
        score[playerIndex] += numPoints;
        UpdateScoreCounter(scoreCounters[playerIndex], score[playerIndex]);

        if (score[playerIndex] >= maxPoints)
        {
            EndGame(playerIndex);
        }
    }

    private void EndGame(int winnerIndex)
    {
        ResetScene();
    }

    private void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void UpdateScoreCounter(TMP_Text scoreCounter, int score)
    {
        scoreCounter.text = score.ToString();
    }
}
