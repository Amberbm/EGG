using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoralityColorManager : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        ManageColors();
    }


    void ManageColors()
    {
        float color = (slider.value -slider.minValue)/ ((slider.maxValue - slider.minValue)/2);
        if (color<1)
            GetComponent<Image>().color = new Color(1,color, 0);
        else
            GetComponent<Image>().color = new Color(1-(color -1), 1, 0);

    }
}
