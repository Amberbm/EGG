using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Lean.Common;
using Lean.Transition;

public class MoneyManager : MonoBehaviour
{
    public static int amount=10; //total amount of money the player has
    public Text text;
    public static int income = 0;

    //show the total amount of money and the "daily" income into the screen
    void Update()
    {
        text.text =  "Money: " + amount
            + "\n +" + income;
    }
    
    //adds money to the total amount(or removes money when using negative )
    public void IncreaseFunds(int num) //for events
    {
        amount += num;
    }

    //adds income to the total amount of money
    public void GetIncome() //at the end of each turn
    {
        amount += income;
    }

    //set income tho the calulated worth of all owned properties
    public void SetIncome()//after each change
    {
        income = PropertyManager.CalculateIncome();
    }
}