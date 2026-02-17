using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
