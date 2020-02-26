﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PropertyObject : MonoBehaviour
{
    public string propertyName;
    public List<string> Tags; //list of tags in the form of strings
    public int baseWorth; //amount of income the player get from this object without the tag factors
    public int price;
    public int id;
    public List<float> factors;
    float influenceFactor = 1;
   
    //event to add property to the list of all existing properties
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } }[SerializeField] private UnityEvent add;

    public UnityEvent AddTags { get { if (addtags == null) addtags = new UnityEvent(); return addtags; } }
    [SerializeField] private UnityEvent addtags;

    // Start is called before the first frame update
    // add propertie to list of all existing kinds of properties
    void Start()
    {
        Add.Invoke();
        AddTags.Invoke();
    }

    public void AddTag(Tag tag)
    {
        Tags.Add(tag.tagName);
    }

    

    //check of all requirments for the property to be shown and bought are shown
    public bool RequirmentsMeet()
    {
        if (MoneyManager.amount >= price)
            return true;
        return false;
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