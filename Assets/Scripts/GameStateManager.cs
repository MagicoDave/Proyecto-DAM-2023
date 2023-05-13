using UnityEngine;

// Manages logic for game status actions
public class GameStateManager : MonoBehaviour
{
    // Used to control the state of the game, if the game over status is on
    public static bool gameOver;
    // Reference to the gameOverUI
    public GameObject gameOverUI;

    // Initializes gameOver at false
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    // Set the game state to Game Over
    void EndGame()
    {
        gameOver = true;

        gameOverUI.SetActive(true);
    }
}
