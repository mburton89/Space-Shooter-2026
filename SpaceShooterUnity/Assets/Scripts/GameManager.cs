using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioClip GameOverSound;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverDelay());
        AudioSource.PlayClipAtPoint(GameOverSound, Camera.main.transform.position);
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
