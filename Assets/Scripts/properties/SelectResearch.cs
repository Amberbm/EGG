using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectResearch : MonoBehaviour
{
    public static int SelectedResearch = 0;

    void Start()
    {
        SetBuyList();
    }

    //set the value of the dropdown in a static variable so it can be called in other classes
    public void SetSelected()
    {
        SelectedResearch = GetComponent<Dropdown>().value;
    }

    //set all possible Research as option int the dropdown list
    public void SetBuyList()
    {
        List<string> list = new List<string> { };
        GetComponent<Dropdown>().ClearOptions();
        for (int i = 0; i < PropertyManager.PossibleResearch; i++)
            list.Add(PropertyManager.AllResearch.Find(x => x.id == i).ResearchName);
        GetComponent<Dropdown>().AddOptions(list);
    }
}
