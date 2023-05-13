using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the MainMenu screen logic
public class MainMenuScript : MonoBehaviour
{
    // Sends player to the game screen
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
