using System;
using UnityEngine;
using UnityEngine.UI;   //need to use UI API in order to get access to Image and Button Objects
using TMPro;

public class HUD : MonoBehaviour
{

    public static HUD Instance;

    public Image healthbarFill;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highestWaveText;

    private void Awake()
    {
        Instance = this;

    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthbarFill.fillAmount = healthAmount;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void DisplayWave(int currentWave)
    {
        Debug.Log("WAVE: " + currentWave);
        waveText.SetText("Wave: " + currentWave);
    }

    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("BEST: " + highestWave);
    }
}
