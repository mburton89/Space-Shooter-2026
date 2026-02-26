using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class IntroVideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "Main Menu";

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}
