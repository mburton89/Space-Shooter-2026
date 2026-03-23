using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentWave = 1;

    private void Awake()
    {
        Instance = this;
    }

    // NEW: Called when wave is cleared
    public void OnWaveCompleted()
    {
        Debug.Log("Wave Complete!");

        PlayerShip player = FindObjectOfType<PlayerShip>();

        if (player != null)
        {
            player.Heal(1); // HEAL HERE
        }

        currentWave++;

        HUD.Instance.DisplayWave(currentWave);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}