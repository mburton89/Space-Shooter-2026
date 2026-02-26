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
    public TextMeshProUGUI turboShotCount;

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
        Debug.Log("WAVE: " + currentWave);
        waveText.SetText("WAVE: " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("Best " + highestWave);
    }

    internal void DisplayTurboShot(int currentTurboShot)
    {
        turboShotCount.SetText("TurboShot Count: " + currentTurboShot);
    }

}
