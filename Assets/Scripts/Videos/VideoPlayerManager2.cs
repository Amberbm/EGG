using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerManager2 : MonoBehaviour
{
    public VideoPlayer videoPlayer, videoPlayer2;
public string scene;
bool started, started2;

// Update is called once per frame
void Update()
{
    if (videoPlayer.isPlaying)
    {
        started = true;
    }
    
    if (started && !videoPlayer.isPlaying)
    {
            videoPlayer2.Play();
            started = false;
    }

    if(videoPlayer2.isPlaying)
        {
            started2 = true;
        }

    if(started2 && !videoPlayer2.isPlaying)
        {
            SceneManager.LoadScene(scene);
        }


}
}
