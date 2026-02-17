// Updated upstream
using System;
using System.Collections;
// Stashed changes
using UnityEngine;
using UnityEngine.UI; //meed to use UI API in order to get acces to Image and Button objects
using TMPro;
using System;

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
// Updated upstream
        Debug.Log("WAVE: " + currentWave);

        Debug.Log("WAVE: " +  currentWave);
        waveText.SetText("WAVE: " + currentWave);

    }

    internal void DisplayHighestWave(int highestWave)
    {

        highestWaveText.SetText("BEST: " + highestWave);
    
 // Stashed changes
    }
}
