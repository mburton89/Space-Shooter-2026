using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

  public static HUD Instance;
  public Image healthBarFill;
  public Image turboBarFill;

  public TextMeshProUGUI waveText;
  public TextMeshProUGUI highestWaveText;
  public TextMeshProUGUI turboShotsText;

  private void Awake()
  {
    Instance = this;
  }


  public void UpdateHealthUI(int currentHP, int maxHP)
  {
    float healthPer = currentHP / (float)maxHP;
    healthBarFill.fillAmount = healthPer;

  }

  public void UpdateTurboUI(float turbo, float maxTurbo)
  {
    float percent = turbo / maxTurbo;
    turboBarFill.fillAmount = percent;

  }

  public void DisplayWave(int currentWave)
  {
    waveText.SetText("WAVE " + (currentWave - 1));
  }

  public void UpdateTurbos(int turbos)
  {
    turboShotsText.SetText(turbos + "/3 TURBOSHOTS");
  }

  public void DisplayHighestWave(int highestWave)
  {
    highestWaveText.SetText("BEST " + (highestWave - 1));
  }
}
