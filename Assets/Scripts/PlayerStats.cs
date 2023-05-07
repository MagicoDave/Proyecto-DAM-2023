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

    void Start()
    {
        money = startMoney;
    }

}
