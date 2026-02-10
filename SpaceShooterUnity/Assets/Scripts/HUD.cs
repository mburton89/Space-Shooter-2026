using UnityEngine;
using UnityEngine.UI; //need to us4e Ui API in order to get acces to Image and Button Objects
public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;


    private void Awake()
    {
        Instance = this;
    }
    public void UpdateHealthUI(int currenHeatlh, int maxHealth)
    {
        float healthAmount = (float) currenHeatlh / (float)maxHealth;

        healthBarFill.fillAmount = healthAmount;
    }
}
