using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button startButton;

   
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
