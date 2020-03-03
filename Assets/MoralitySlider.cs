using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoralitySlider : MonoBehaviour
{
    public static float value;
    void Start()
    {
        value = GetComponent<Slider>().value;
    }

   
    
     
    public void ChangeValue(int num)
    {
        GetComponent<Slider>().value += num;
        value = GetComponent<Slider>().value;
    }
    
}
