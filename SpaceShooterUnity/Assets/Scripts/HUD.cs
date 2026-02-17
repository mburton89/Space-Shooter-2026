using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI; //need to use UI API in order to get access to Image and Button objects
using TMPro; //gets access to TextMeshPro to use while coding

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }

    internal void DisplayWave(int currentWave)
    {
        waveText.SetText("Round " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("Best: " + highestWave);
    }
}