using System;
using UnityEngine;
using UnityEngine.UI; // beed to use UI API in order to get access to Image and Button objects

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        Debug.Log("WAVE: " + currentWave);
    }
}
