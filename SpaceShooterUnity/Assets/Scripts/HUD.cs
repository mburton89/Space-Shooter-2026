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
    public TextMeshProUGUI currentBombsText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        // Health percentage (healthAmount) = currentHealth / maxHealth

        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;

    }

    public void UpdateGlitterBombInventory(int currentGlitterBombs)
    {
        currentBombsText.SetText("G. BOMBS: " + currentGlitterBombs);
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
}
