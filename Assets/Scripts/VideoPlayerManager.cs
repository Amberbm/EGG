using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    bool started;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Console.WriteLine("work");
        if (videoPlayer.isPlaying)
        {
            started = true;
        }

        if(started && !videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
