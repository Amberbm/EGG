using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Lean.Common;
using Lean.Transition;

public class MoneyManager : MonoBehaviour
{
    public static int amount=1000; //total amount of money the player has
    public Text text;
    public int extraincome; 
    public static int income = 0;
    float percentage;

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

    public void Percentage(int num)
    {
        percentage = ((float)num / 100) * amount;
        amount -= (int)percentage;
    }

    public void PercentageIncrease(int num)
    {
        percentage = ((float)num / 100) * amount;
        amount += (int)percentage;
    }

    public void Moneychangelow(int num)
    {
        if (Notificationmanager.low)
            amount += num;
    }

    public void Moneychangehigh(int num)
    {
        if (Notificationmanager.high)
            amount += num;
    }

    public void ChangeIncome(int num)
    {
        extraincome += num;
    }

    //set income tho the calulated worth of all owned properties
    public void SetIncome()//after each change
    {
        income = PropertyManager.CalculateIncome() + extraincome;
    }
}