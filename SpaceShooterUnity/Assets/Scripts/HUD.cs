//Deleted top one because it made "Image" have two definitions
using System;
using UnityEngine;
using UnityEngine.UI; //Need to use Unity UI API to access Image and Button components
using TMPro; //so we can use textmeshpro for text

public class HUD : MonoBehaviour
{
    public static HUD Instance; //Make this a singleton to access from other scripts
    public Image healthBarFill;
    public Image turboShotOne; //ref to turbo shot one
    public Image turboShotTwo; //ref to turbo shot 2
    public Image turboShotThree; //ref to turbo shot 3

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

    public void UpdateTurboShotUI(int currentTurboShots)
    {
        Debug.Log("Current Turbo Shots:" + currentTurboShots);
        Ship playerShip = FindObjectOfType<PlayerShip>();
        
        //this function updates vis of turbo shot images
        if (playerShip.currentTurboShots == 0)
        {
            Debug.Log("Turbo0");
            turboShotOne.enabled = false;
            turboShotTwo.enabled = false;
            turboShotThree.enabled = false;
        }
        if (playerShip.currentTurboShots == 1)
        {
            Debug.Log("Turbo1");
            turboShotOne.enabled = true;
            turboShotTwo.enabled = false;
            turboShotThree.enabled = false;
        }
        if (playerShip.currentTurboShots == 2)
        {
            Debug.Log("Turbo2");
            turboShotOne.enabled = true;
            turboShotTwo.enabled = true;
            turboShotThree.enabled = false;
        }
        if (playerShip.currentTurboShots == 3)
        {
            Debug.Log("Turbo3");
            turboShotOne.enabled = true;
            turboShotTwo.enabled = true;
            turboShotThree.enabled = true;
        }
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
