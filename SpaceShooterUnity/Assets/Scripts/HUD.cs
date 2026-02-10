using UnityEngine;
using UnityEngine.UI; //need to use UI API in order to get acess to image and button objects

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        float healthAmount = (float)currentHealth / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }
}
