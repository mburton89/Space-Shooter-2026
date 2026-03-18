using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool gamePaused;
    public GameObject PausePanel;
    public GameObject PauseIcon;

    // Update is called once per frame

    private void Start()
    {
        PausePanel.SetActive(false);
        PauseIcon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            gamePaused = !gamePaused;
            PauseGame();
            Debug.Log("Game Paused."); // Print to console for testing purposes

        }
    }

    public void EnablePauseMenu()
    {
        PausePanel.SetActive(true);
        PauseIcon.SetActive(true);
    }
    public void DisablePauseMenu()
    {
        PausePanel.SetActive(false);
        PauseIcon.SetActive(false);
    }

    void PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            PauseIcon.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            PauseIcon.SetActive(false);
        }
    }

}