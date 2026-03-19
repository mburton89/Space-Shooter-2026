using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static PauseMenu Instance;

    public GameObject pauseMenuCanvas;

    public Button resumeButton;
    public Button menuButton;
    public Button musicToggleButton;

    public TextMeshProUGUI musicToggleButtonText;

    public bool pauseMenuIsActive;
    public bool musicToggledOn;

    public AudioSource gameplayMusic;

    private float fixedDeltaTime;

    private void Awake()
    {
        Instance = this;
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        pauseMenuIsActive = false;
        musicToggledOn = true;

        resumeButton.onClick.AddListener(HandlePauseMenuClosed);
        menuButton.onClick.AddListener(HandleReturnToMainMenu);
        musicToggleButton.onClick.AddListener(HandleMusicToggle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuIsActive == false)
            {
                HandlePauseMenuOpened();
            }
            else if (pauseMenuIsActive == true)
            {
                HandlePauseMenuClosed();
            }
        }
    }

    public void HandlePauseMenuOpened()
    {
        pauseMenuCanvas.SetActive(true);
        pauseMenuIsActive = true;
        Time.timeScale = 0f;
        Debug.Log("Pause Menu Opened");
    }

    public void HandlePauseMenuClosed()
    {
        pauseMenuCanvas.SetActive(false);
        pauseMenuIsActive = false;
        Time.timeScale = 1f;
        Debug.Log("Pause Menu Closed");
    }
    public void HandleReturnToMainMenu()
    {
        HandlePauseMenuClosed();
        SceneManager.LoadScene(0);
    }
    public void HandleMusicToggle()
    {
        if (musicToggledOn == true)
        {
            Debug.Log("Music Off");
            StopMusic();

            musicToggledOn = false;
            musicToggleButtonText.SetText("MUSIC: OFF");
        }

        else if (musicToggledOn == false)
        {
            Debug.Log("Music On");
            PlayMusic();

            musicToggledOn = true;
            musicToggleButtonText.SetText("MUSIC: ON");
        }
    }

    public void PlayMusic()
    {
        gameplayMusic.Play();
    }

    public void StopMusic()
    {
        gameplayMusic.Stop();
    }
}
