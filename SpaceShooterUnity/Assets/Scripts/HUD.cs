using System;
using UnityEngine;
using UnityEngine.UI; // beed to use UI API in order to get access to Image and Button objects
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

 // public float healthFlash = 10f;

    private void Awake()
    {
        Instance = this;
    }

 //   private void Update()
 // {
 //     if (healthFlash <= 3)
 //       {
 //     healthBarFill.fillAmount = 0;
 //         
 //        healthBarFill.fillAmount = healthFlash;
 //     }
 // }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
      //healthFlash = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        Debug.Log("Wave " + currentWave);
        waveText.SetText("Wave " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("BEST " + highestWave);
    }
}
