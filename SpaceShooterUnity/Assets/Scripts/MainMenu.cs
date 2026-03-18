using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI recordWave;
    public Button startButton;
    public Button creditsButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        creditsButton.onClick.AddListener(HandleCreditsButtonClicked);
        DisplayRecordWave(PlayerPrefs.GetInt("HighestWave"));                                                           
    }

    public void DisplayRecordWave(int highestWave)
    {
        recordWave.SetText("RECORD WAVE: " + highestWave);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    void HandleCreditsButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    void HandleBackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

}
