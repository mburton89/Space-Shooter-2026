//Deleted top one because it made "Image" have two definitions
using UnityEngine;
using UnityEngine.UI; //Need to use Unity UI API to access Image and Button components

public class HUD : MonoBehaviour
{
    public static HUD Instance; //Make this a singleton to access from other scripts
    public Image healthBarFill;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth; //Calculate percent of health remaining
        healthBarFill.fillAmount = healthAmount; //Change health bar filling to match health amount
    }
}
