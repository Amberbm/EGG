using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectProperty : MonoBehaviour
{
    public static int SelectedProperty = 0;

    //set the value of the dropdown in a static variable so it can be called in other classes
    public void setSelected()
    {
        SelectedProperty = GetComponent<Dropdown>().value ;
    }

    //set all possible properties as option int the dropdown list
    public void SetBuyList()
    {
        List<string> list = new List<string> { };
        GetComponent<Dropdown>().ClearOptions();
        for (int i = 0; i < PropertyManager.PossibleProperties; i++)
            list.Add(PropertyManager.AllProperties.Find(x=> x.id == i).propertyName);
        GetComponent<Dropdown>().AddOptions(list);
    }

   
}