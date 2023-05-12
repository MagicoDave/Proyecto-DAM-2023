using UnityEngine;

// Manages logic for game status actions
public class GameStateManager : MonoBehaviour
{

    private bool gameOver = false;

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

    // Game over event
    void EndGame()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}
