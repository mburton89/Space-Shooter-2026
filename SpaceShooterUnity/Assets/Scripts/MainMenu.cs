using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);
    }

  void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    void HandleQuitButtonClicked()
    {
        Application.Quit();
    }
}
