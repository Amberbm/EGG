using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{

    public Text text;
    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        text.text = (int)slider.value + "";
    }
}
