using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Morality : MonoBehaviour
{
    public static float value;
    void Start()
    {
        value = GetComponent<Slider>().value;
    }

    void Update()
    {
        GetComponent<Slider>().value = value;
    }
     
    public void ChangeValue(int num)
    {
        value += num;
    }


    public void Moralitychangelow(int num)
    {
        if (Notificationmanager.low)
            value += num;

        if (value < -100)
            value = -100;
        if (value > 100)
            value = 100;
    }

    public void Moralitychangehigh(int num)
    {
        if (Notificationmanager.high)
            value += num;
    }


}
