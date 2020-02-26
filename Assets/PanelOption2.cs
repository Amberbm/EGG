using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOption2 : MonoBehaviour
{
    public Text text;
    //set text in te option 2 button
    public void SetOption()
    {
        text.text = EventManager.currentEvent.stringOption2;
    }

}