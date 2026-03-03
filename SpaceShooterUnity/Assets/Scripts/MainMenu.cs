using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
  public Button startButton;
  public Button resetScoreButton;
  public TextMeshProUGUI highscoreText;

  int highscore;

  // Start is called before the first frame update
  void Start()
  {
    highscore = PlayerPrefs.GetInt("waveHighscore");
    highscoreText.SetText("BEST: " + (highscore - 1) + " WAVES");

    startButton.onClick.AddListener(HandleStartButtonClicked);
    resetScoreButton.onClick.AddListener(HandleResetScoreClicked);
  }

  void HandleStartButtonClicked()
  {
    SceneManager.LoadScene(1);
  }

  void HandleResetScoreClicked()
  {
    PlayerPrefs.SetInt("waveHighscore", 0);
    highscore = PlayerPrefs.GetInt("waveHighscore");
    highscoreText.SetText("BEST: " + highscore + " WAVES");
  }


}
