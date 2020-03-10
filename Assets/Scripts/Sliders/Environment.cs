using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour
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
        Morality.value -= num * value * 0.01f;
    }


}
