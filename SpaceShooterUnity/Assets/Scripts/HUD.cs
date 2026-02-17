using System;
using UnityEngine;
using UnityEngine.UI; //Remember for UI
using TMPro;

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

    public void DisplayWave(int currentWave)
    {
        Debug.Log("Wave: " + currentWave);
        waveText.SetText("Wave: " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("Best: " + highestWave);
    }
}
