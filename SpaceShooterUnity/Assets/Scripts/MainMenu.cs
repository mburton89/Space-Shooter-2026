using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI recordWave;
    public Button startButton;
    public Button creditsButton;

    public AudioSource selectAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        creditsButton.onClick.AddListener(HandleCreditsButtonClicked);
        DisplayRecordWave(PlayerPrefs.GetInt("HighestWave"));                                                           
    }

    public void DisplayRecordWave(int highestWave)
    {
        recordWave.SetText("HIGH SCORE: " + highestWave);
    }

    void HandleStartButtonClicked()
    {
        selectAudioSource.Play();
        SceneManager.LoadScene(1);
    }

    void HandleCreditsButtonClicked()
    {
        selectAudioSource.Play();
        SceneManager.LoadScene(2);
    }

    void HandleBackButtonClicked()
    {
        selectAudioSource.Play();
        SceneManager.LoadScene(0);
    }

}
