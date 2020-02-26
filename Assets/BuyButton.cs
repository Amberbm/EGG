using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuyButton : MonoBehaviour
{

    public Text text;
    public static PropertyObject property;
    public PropertyObject Checkproperty;


    void Start()
    {
        SetProperty();
    }

    

    void Update()
    {
        //checks wheather the player should be able to press the buybutton
        if (PropertyManager.AllProperties.Exists(x => x.id == 0))
        {
            if (property.price != null)
            {
                if (property.price <= MoneyManager.amount)
                    GetComponent<Button>().interactable = true;
                else
                    GetComponent<Button>().interactable = false;
            }
        }
        else
            GetComponent<Button>().interactable = false;
        
    }

    //Declare which property is selected for the buy button and set the buttons text accordingly
    public void SetProperty()
    {
        property = PropertyManager.AllProperties.Find(x=> x.id == SelectProperty.SelectedProperty);
        Checkproperty = property;
        if (property != null)
            text.text = "Buy " + property.propertyName + "  $" + property.price;
        else
            text.text = "";
    }
}