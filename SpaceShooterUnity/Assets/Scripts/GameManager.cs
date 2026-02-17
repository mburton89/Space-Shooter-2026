using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
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
