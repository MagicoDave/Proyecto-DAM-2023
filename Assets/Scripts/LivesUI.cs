using TMPro;
using UnityEngine;

// Logic to update the text of the UI with the ammount of lives the player has left
public class LivesUI : MonoBehaviour
{
    
    public TextMeshProUGUI txtLives;

    // Update is called once per frame
    void Update()
    {
        txtLives.text = PlayerStats.lives.ToString("D2");
    }
}
