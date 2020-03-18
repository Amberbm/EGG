using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    static public int dayCount = 1;
    public Text text;
    public bool finish;

    
    public void NextDay()//after each turn
    {
        dayCount++;
        text.text = "Days: " + dayCount;

        if (dayCount == 10)
            finish = true;
    }
}