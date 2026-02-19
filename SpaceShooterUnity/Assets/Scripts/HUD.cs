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

    public TextMeshProUGUI currentShot;

    public TextMeshProUGUI shotText;


    private void Awake()
    {
        Instance = this;
    }

    public void updateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        Debug.Log("WAVE: " + currentWave);
        waveText.SetText("WAVE: " + currentWave);
    }

    public void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("BEST: " + highestWave);
    }

    public void DisplayShotUI(float currentShot)
    {
        Debug.Log("Special: " + currentShot);
        shotText.SetText("Charge: " + currentShot);
    }

}
