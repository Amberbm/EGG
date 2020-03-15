using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuyResearchButton : MonoBehaviour
{
    public Text text;
    public static Research research;
    public Text Description;

    void Start()
    {
        SetResearch();
    }

    void Update()
    {
        //checks wheather the player should be able to press the buybutton
        if (PropertyManager.AllResearch.Exists(x => x.id == 0))
        {
            if (research.price != null)
            {
                if (research.price <= MoneyManager.amount)
                    GetComponent<Button>().interactable = true;
                else
                    GetComponent<Button>().interactable = false;
            }
        }
        else
            GetComponent<Button>().interactable = false;
    }


    //Declare which property is selected for the buy button and set the buttons text accordingly
    public void SetResearch()
    {
        research = PropertyManager.AllResearch.Find(x => x.id == SelectResearch.SelectedResearch);
        if (research != null)
        {
            text.text = "Buy " + research.ResearchName + "  $" + research.price;
            Description.text = research.Description;
        }
        else
        {
            text.text = "";
            Description.text = "";
        }
    }
}