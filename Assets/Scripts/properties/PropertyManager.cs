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
    public UnityEvent SetBuyList { get { if (setBuyList == null) setBuyList = new UnityEvent(); return setBuyList; } }
    [SerializeField] private UnityEvent setBuyList;

    public static List<PropertyObject> AllProperties = new List<PropertyObject> { }; // List of all existing kinds of properties
    public static List<PropertyObject> properties = new List<PropertyObject> { }; //List of all properties aquired by the player
    public static List<Research> AllResearch = new List<Research> { };
    public static List<Upgrade> AllUpgrades = new List<Upgrade> { };
    public static List<Tag> tags = new List<Tag> {}; 
    
    public static int PossibleProperties; //range of ids of the properties that the player can buy
    public static int PossibleResearch;
    public static int UpgradeLevel = 0;//current gameStage

    

    public void SetFactor(Tag tag, float factor)
    {
        tags.Find(x => x.tagName == tag.tagName).InfluenceFactor = factor ;
    }

    //add property to the list of all porrible properties
    public void AddProperty(PropertyObject property)
    {
        AllProperties.Add(property);
        SetPossibleProperties();
        SetBuyList.Invoke();
    }

    //add tag to te list of tags
    public void AddTags(Tag tag) //at start of the game (possibly in an event)
    {
        tags.Add(tag);
    }

    public void AddResearch(Research research)
    {
        AllResearch.Add(research);
        SetPossibleResearch();
        SetBuyList.Invoke();
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        AllUpgrades.Add(upgrade);
        SetBuyList.Invoke();
    }

    //add property to the list of aquired properties and subtract its price from the total amount of money
    public void BuyProperty()
    {
        PropertyObject property = BuyPropertyButton.property;
        properties.Add(property);
        MoneyManager.amount -= property.price;
        SetPossibleProperties();
        property.AtBuying();
    }

    public void BuyResearch()
    {
        BuyResearchButton.research.BuyResearch();
    }

    public void BuyUpgrade()
    {
        UpgradeLevel++;
        MoneyManager.amount -= AllUpgrades.Find(x => x.upgradeLevel == UpgradeLevel).price;
    }

    public void GetProperty(string name) //for event
    {
        PropertyObject property = AllProperties.Find(x => x.propertyName == name);
        properties.Add(property);
    }

    //give all properties with the right requirements their own id and set the range of the id's
    //properties that players are unable to buy are given the id of -1 so they fall outside of the range
    public void SetPossibleProperties()//after each change
    {
        PossibleProperties = 0;
        foreach (PropertyObject propertyObject in AllProperties)
        {
            if (propertyObject.RequirmentsMeet())
            {
                propertyObject.id = PossibleProperties;
                PossibleProperties++;
            }
            else
                propertyObject.id = -1;
        }
    }

    public void SetPossibleResearch()
    {
        PossibleResearch = 0;
        foreach (Research research in AllResearch)
        {
            if (research.RequirmentsMeet())
            {
                research.id = PossibleResearch;
                PossibleResearch++;
            }
            else
                research.id = -1;
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