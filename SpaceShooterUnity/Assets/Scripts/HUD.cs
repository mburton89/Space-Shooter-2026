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
    public TextMeshProUGUI currentShotText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayWave(int currentWave)
    {
        Debug.Log("WAVE: " + currentWave);
        waveText.SetText("Wave: " + currentWave);
    }

    public void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("BEST: " + highestWave);
    }

    public void UpdateTurboUI(float currentCharge)
    {
        throw new NotImplementedException();
    }

    public void DisplayShot(float currentShot)
    {
        Debug.Log("Charge: " + currentShot);
        waveText.SetText("Charge: " + currentShot);
    }

}
