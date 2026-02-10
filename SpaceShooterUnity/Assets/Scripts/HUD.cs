using UnityEngine;
using UnityEngine.UI;   //need to use UI API in order to get access to Image and Button Objects

public class HUD : MonoBehaviour
{

    public static HUD Instance;

    public Image healthbarFill;

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
}
