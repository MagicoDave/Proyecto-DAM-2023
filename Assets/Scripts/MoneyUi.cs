using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Logic to update the UI text with the money the player has
public class MoneyUi : MonoBehaviour
{

    public TextMeshProUGUI txtMoney;

    // Update is called once per frame
    void Update()
    {
        txtMoney.text = PlayerStats.money.ToString("D6");
    }
}
