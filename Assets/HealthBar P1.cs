using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages Health Bar for Player 1

public class HealthBarP1 : MonoBehaviour
{
    public Slider slider; // Health Bar slider

    public void SetMaxHealth(int health) // Takes health from Player Guy
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
