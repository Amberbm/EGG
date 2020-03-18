using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Research : MonoBehaviour
{
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } }
    [SerializeField] private UnityEvent add;

    public int id;
    public string ResearchName;
    public string Description;
    public int price;
    public int morality;
    public int influence;
    public int environment;
    bool gameJustStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameJustStarted)
        {
            Add.Invoke();
            gameJustStarted = false;
        }
    }

    public bool RequirmentsMeet()
    {
        if (MoneyManager.amount < price)
            return false;
        return true;
    }

    public void BuyResearch()
    {
        Environment.value += environment;
        Influence.value += influence;
        Morality.value += morality;// - (int)((float)environment * Environment.value * 0.01f);
        MoneyManager.amount -= price;
    }

    
}
