using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Credits : MonoBehaviour
{
    public Button backButton;
    public AudioSource selectAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backButton.onClick.AddListener(HandleBackButtonClicked);
    }

    void HandleBackButtonClicked()
    {
        selectAudioSource.Play();
        SceneManager.LoadScene(0);
    }

}
