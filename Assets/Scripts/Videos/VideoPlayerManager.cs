using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string scene;
    bool started;

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            started = true;
        }

        if(started && !videoPlayer.isPlaying)
        {
            SceneManager.LoadScene(scene);
        }


    }
}
