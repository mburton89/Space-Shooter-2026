//Deleted top one because it made "Image" have two definitions
using System;
using UnityEngine;
using UnityEngine.UI; //Need to use Unity UI API to access Image and Button components
using TMPro; //so we can use textmeshpro for text

public class HUD : MonoBehaviour
{
    public static HUD Instance; //Make this a singleton to access from other scripts
    public Image healthBarFill;

    public TextMeshProUGUI waveText; //ref to wave text

    public TextMeshProUGUI highestWaveText; //High score text
 

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth; //Calculate percent of health remaining
        healthBarFill.fillAmount = healthAmount; //Change health bar filling to match health amount
    }

    internal void DisplayWave(int currentWave)
    {
        Debug.Log("WAVE:" + currentWave); //This will print to console so we can test
        waveText.SetText("Wave " + currentWave); //Updating wave count on UI

    }
    
    internal void DisplayHighestWave(int highestWave)
    {
        highestWaveText.SetText("HI SCORE: " + highestWave); //Updating high score on UI

      
        
    }
}
