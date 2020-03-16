using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Influence : MonoBehaviour
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
        if (value < 0)
            value = 0;
        if (value > 100)
            value = 100;
    }

    public void Influencechangelow(int num)
    {
        if (Notificationmanager.low)
            value += num;
    }

    public void Influencechangehigh(int num)
    {
        if (Notificationmanager.high)
            value += num;
    }

}
