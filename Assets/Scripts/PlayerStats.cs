using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages player variables like money or lifes
public class PlayerStats : MonoBehaviour
{
    // Money, used to buy turrets
    public static int money;
    // Default starting ammount of money
    public int startMoney = 400;

    // Lifes, the ammount of damage enemies can do before you lose
    public static int lives;
    // Default starting ammount of lives
    public int startLives = 20;

    // Number of the round
    public static int wave;

    // Initializates the player stats with default values
    void Start()
    {
        money = startMoney;
        lives = startLives;
        wave = 0;
    }

}
