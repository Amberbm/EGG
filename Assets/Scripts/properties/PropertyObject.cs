using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PropertyObject : MonoBehaviour
{
    public int id;
    public string propertyName;
    public List<string> Tags; //list of tags in the form of strings
    public int baseWorth; //amount of income the player get from this object without the tag factors
    public int price;
    float influenceFactor = 1;
    public int morality;
    public int influence;
    public int environment;

    public string Description;
    public bool unbuyable;
   
    //event to add property to the list of all existing properties
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } }[SerializeField] private UnityEvent add;
    

    // Start is called before the first frame update
    // add propertie to list of all existing kinds of properties
    void Start()
    {
        Add.Invoke();
    }

    public void AddTag(Tag tag)
    {
        Tags.Add(tag.tagName);
    }

    public void AtBuying()
    {
        Environment.value += environment;
        Influence.value += influence;
        Morality.value += morality - (int)((float)environment * Environment.value * 0.01f);
    }
    

    //check of all requirments for the property to be shown and bought are shown
    public bool RequirmentsMeet()
    {
        if (MoneyManager.amount < price)
            return false ;
        if (unbuyable)
            return false;
        return true;
    }

    //calculate the worth of the property based on the base worth and the factors of its tags
    public int CalculateWorth()//when calculating the total income
    {
        float worth = (float)baseWorth;
        foreach (string tag in Tags)
            worth *= PropertyManager.tags.Find(x=> x.tagName ==tag).InfluenceFactor;
        return (int)worth;
    }
}