using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelDescription : MonoBehaviour
{
    public Text text;
    //set te text of the eventDescription
    public void SetDescription()
    {
        text.text = EventManager.currentEvent.eventDescription;
    }
}
