using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Flag to keep track of game pause state
    public bool isGamePaused = false;
    
    // Update is called once per frame
    void Update()
    {
        // Check for pause input (e.g., pressing 'P' key)
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle game pause state
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Set time scale to 0 to pause the game
        Time.timeScale = 0f;
        isGamePaused = true;
        // TODO: Add code to display pause menu if desired
    }

    public void ResumeGame()
    {
        // Set time scale to 1 to resume the game
        Time.timeScale = 1f;
        isGamePaused = false;
        // TODO: Add code to hide pause menu if desired
    }
}
