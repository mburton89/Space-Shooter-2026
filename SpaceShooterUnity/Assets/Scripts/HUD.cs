using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

  public static HUD Instance;
  public Image healthBarFill;

  private void Awake()
  {
    Instance = this;
  }

  public void UpdateHealthUI(int currentHP, int maxHP)
  {
    float healthPer = currentHP / (float)maxHP;
    healthBarFill.fillAmount = healthPer;

  }

  public void DisplayWave(int currentWave)
  {

  }
}
