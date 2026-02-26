using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;
    public TextMeshProUGUI turboShotText;

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
        waveText.SetText("WAVE: " + currentWave);
        
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("BEST: " + highestWave);
    }

    public void DisplayTurboShot(int currentTurboShot)
    {
        turboShotText.SetText("Turbo Shots: " + currentTurboShot);
    }

}
