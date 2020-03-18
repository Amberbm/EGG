using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Stagemanager : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public AudioSource audio1, audio2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(PropertyManager.UpgradeLevel == 1)
        {
            image1.SetActive(true);
            image2.SetActive(false);
            if (!audio1.isPlaying)
                audio1.Play();
            if (audio2.isPlaying)
                audio2.Pause();
        }
        else if(PropertyManager.UpgradeLevel == 2)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            if (audio1.isPlaying)
                audio1.Pause();
            if (!audio2.isPlaying)
                audio2.Play();
        }
    }
}
