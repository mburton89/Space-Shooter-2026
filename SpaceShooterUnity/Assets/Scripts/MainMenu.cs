using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button startButton;

    public AudioSource musicAudioSource;
    public AudioClip musicClipToLoop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);

        musicAudioSource.clip = musicClipToLoop;

        musicAudioSource.loop = true;
        musicAudioSource.Play();
        

    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
  
}