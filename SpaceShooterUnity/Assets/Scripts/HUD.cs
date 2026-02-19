using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

  public static HUD Instance;
  public Image healthBarFill;

  public TextMeshProUGUI waveText;
  public TextMeshProUGUI highestWaveText;

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
    waveText.SetText("WAVE " + (currentWave - 1));
  }

  public void DisplayHighestWave(int highestWave)
  {
    highestWaveText.SetText("BEST " + (highestWave - 1));
  }
}
