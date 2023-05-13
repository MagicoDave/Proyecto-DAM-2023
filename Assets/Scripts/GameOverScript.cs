using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the gameOverUI
public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    // Used to get the correct number of waves survived when the gameover screen pops up
    private void OnEnable()
    {
        waveText.text = PlayerStats.wave.ToString();
    }

    // Restarts the current level
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Goes back to Main Menu
    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
