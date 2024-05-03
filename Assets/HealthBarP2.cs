using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages Health Bar for Player 2
public class HealthBar : MonoBehaviour
{
    public Slider slider; // Health Bar slider

    public void SetMaxHealth(int health) // takes health from Player Dude
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
