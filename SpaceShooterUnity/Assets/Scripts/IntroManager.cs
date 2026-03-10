using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class IntroManager : MonoBehaviour
{
    public string nextSceneName = "Main Menu";
    public float waitTime = 3f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(1);
    }

}
