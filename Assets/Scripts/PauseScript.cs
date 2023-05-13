using UnityEngine;
using UnityEngine.SceneManagement;

// This manages the pause menu
public class PauseScript : MonoBehaviour
{
    public GameObject ui;

    // Reads the Escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    // Toogles the pause UI and stops/reanudates the game
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf )
        {
            Time.timeScale = 0.0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    // Restarts the level
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Returns to main menu
    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
