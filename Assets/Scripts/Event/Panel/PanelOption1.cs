using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOption1 : MonoBehaviour
{
    public Text text;
    //set text in te option 1 button
    public void SetOption()
    {
        text.text = EventManager.currentEvent.stringOption1;
    }
}