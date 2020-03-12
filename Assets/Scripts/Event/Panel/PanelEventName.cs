using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelEventName : MonoBehaviour
{
    public Text text;
    //set the text of the eventName
    public void SetEventname()
    {
        text.text = EventManager.currentEvent.eventName;
    }
}
