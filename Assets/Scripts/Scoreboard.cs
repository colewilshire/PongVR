using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    private int maxPoints = 2;
    private int[] score = {0, 0};

    public void AddPoint(int playerIndex, int numPoints = 1)
    {
        score[playerIndex] += numPoints;

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
}
