using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Credits : MonoBehaviour
{
    public Button backButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backButton.onClick.AddListener(HandleBackButtonClicked);
    }

    void HandleBackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

}
