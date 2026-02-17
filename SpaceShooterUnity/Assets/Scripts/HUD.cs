using System;
using UnityEngine;
using UnityEngine.UI; //need to use UI API in order to get access to Image and Buttono objects
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance; 


    public Image healthBarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestwaveText;

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
       Debug.Log("Wave: " +  currentWave);
        waveText.SetText("Wave: " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestwaveText.SetText("Best: " + highestWave);
    }
}
