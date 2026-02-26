using System;
using UnityEngine;
using UnityEngine.UI; //need to use UI API in order to get acess to image and button objects
using TMPro; //to get access to textmeshpro

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;
    public TextMeshProUGUI turboPewText;

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
        waveText.SetText("Wave: " +  currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("Best: " +  highestWave);
    }

    public void DisplayTurboPew(int turboPew)
    {
        Ship playerShip = FindObjectOfType<PlayerShip>();
        Debug.Log("Turbo Pew: " + playerShip.turboPewPew);
        turboPewText.SetText("Turbo pews " + playerShip.turboPewPew);
    }
}
