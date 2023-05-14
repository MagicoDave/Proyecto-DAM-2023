using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the victory screen UI
public class YouWonScript : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    // Used to get the correct number of waves survived when the victory screen pops up
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
