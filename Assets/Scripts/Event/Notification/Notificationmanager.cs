using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Notificationmanager : MonoBehaviour
{
    public Text text;
    public string Consequences;
    public static bool low, high;

    void Update()
    {
            text.text = Consequences;
    }

    public void changeConsequences(string name)
    {
        Consequences = name;
    }

    public void checkmorality(int num)
    {
        if (num >= Morality.value)
        {
            high = false;
            low = true;
        }
        else
        {
            high = true;
            low = false;
        }

    }

    public void checkinfluence(int num)
    {
        if (num >= Influence.value)
        {
            high = false;
            low = true;
        }
        else
        {
            high = true;
            low = false;
        }
    }

    public void Low(string text)
    {
        if (low)
            Consequences = text;
    }

    public void High(string text)
    {
        if (high)
            Consequences = text;
    }


}
