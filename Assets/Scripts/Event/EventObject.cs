using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventObject : MonoBehaviour
{
    //event to add the event to the list of all events
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } } [SerializeField] private UnityEvent add;

    public UnityEvent Option1 { get { if (option1 == null) option1 = new UnityEvent(); return option1; } } [SerializeField] private UnityEvent option1;

    public UnityEvent Option2 { get { if (option2 == null) option2 = new UnityEvent(); return option2; } } [SerializeField] private UnityEvent option2;

    public int id;
    public string eventName;
    public string eventDescription;
    public string stringOption1;
    public string eventConsequences;
    public string stringOption2;
    public int minIncome;
    float percentage;

    public List<string> previousEvents ; // list of all previous events that need to have been occured before this event can be shown
    public bool hasHappened;// bool that states weather the event has occured yet

    //bool to check whether an event voldoet aan de requirments to be shown as an event
    public bool EventRequirementsMeet()
    {
        
        if (MoneyManager.amount < minIncome )
            return false;
        //checks for all required previous events weather they have happenedyet
       // foreach (string previousEvent in previousEvents) 
          //  if (!EventManager.AllEvents.Find(x=> x.eventName == previousEvent).hasHappened)
            //    return false;
        return true;
    }

    // Start is called before the first frame update
    //add the event to the eventlist in the eventmanager
    void Start()
    {
        Add.Invoke();
    }
}