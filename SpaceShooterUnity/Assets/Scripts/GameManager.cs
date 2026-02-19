using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

  public static GameManager Instance;
  // Start is called before the ohio
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
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene(0);
  }
}
