using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Lean.Common;
using Lean.Transition;

class PropertyManager : MonoBehaviour
{
    //
    public UnityEvent SetBuyList { get { if (setBuyList == null) setBuyList = new UnityEvent(); return setBuyList; } }
    [SerializeField] private UnityEvent setBuyList;


    public static List<PropertyObject> AllProperties = new List<PropertyObject> { }; // List of all existing kinds of properties
    public List<PropertyObject> CheckList;
    public List<PropertyObject> CheckList2;
    public static List<PropertyObject> properties = new List<PropertyObject> { }; //List of all properties aquired by the player

    public static List<Tag> tags = new List<Tag> {}; 
    public List<Tag> checktags;
    public static int PossibleProperties; //range of ids of the properties that the player can buy
    public int check2;

    public void SetFactor(Tag tag)
    {
        tags.Find(x => x.tagName == tag.tagName).InfluenceFactor *= 2 ;
    }

    public PropertyObject Checkproperty;

    //add property to the list of all possible properties
    public void AddProperty(PropertyObject property)
    {
        AllProperties.Add(property);
        SetBuyList.Invoke();
}

    //add tag to te list of tags
    public void AddTags(Tag tag) //at start of the game (possibly in an event)
    {
        tags.Add(tag);
        checktags = tags;
    }

    //add property to the list of aquired properties and subtract its price from the total amount of money
    public void BuyProperty()
    {
        PropertyObject property = BuyButton.property;
        properties.Add(property);
        MoneyManager.amount -= property.price;
        property.AtBuying();
        if (property.type == "Property")
            SetPropertyList();
        else
            SetResearchList();

        Checkproperty = property;
       CheckList2 = properties;
    }

    public void GetProperty(string name) //for event
    {
        PropertyObject property = AllProperties.Find(x => x.propertyName == name);
        properties.Add(property);
    }

    //give all properties with the right requirements their own id and set the range of the id's
    //properties that players are unable to buy are given the id of -1 so they fall outside of the range
    public void SetPropertyList()//set the list of properties the player can buy
    {
        PossibleProperties = 0;
        foreach (PropertyObject propertyObject in AllProperties)
        {
            if (propertyObject.RequirmentsMeet()&& propertyObject.type =="Property")
            {
                propertyObject.id = PossibleProperties;
                PossibleProperties++;
            }
            else
                propertyObject.id = -1;
        }
    }

    public void SetResearchList()//set the list of research the player can fund
    {
        PossibleProperties = 0;
        foreach (PropertyObject propertyObject in AllProperties)
        {
            if (propertyObject.RequirmentsMeet() && propertyObject.type == "Research")
            {
                propertyObject.id = PossibleProperties;
                PossibleProperties++;
            }
            else
                propertyObject.id = -1;
        }
    }

    //adds the calculated worth's of all aquired properties to eachother to calculate the income
    public static int CalculateIncome()//after each change
    {
        int income = 0;
        foreach (PropertyObject propertyObject in properties)
        {
            income += propertyObject.CalculateWorth();
        }
        return income;
    }
}