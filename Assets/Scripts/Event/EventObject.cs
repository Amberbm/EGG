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

    public List<EventObject> previousEventsSecondOption ; // list of all previous events that need to have been occured before this event where the second option was selected can be shown
    public List<EventObject> previousEventsFirstOption; // list of all previous events that need to have been occured before this event where the First option was selected can be shown
    public bool SecondOptionSelected; //bool that states which option had been selected;
    public bool hasHappened;// bool that states weather the event has occured yet
    public bool HappensOnce;

    //bool to check whether an event voldoet aan de requirments to be shown as an event
    public bool EventRequirementsMeet()
    {
        if (HappensOnce)
            if (hasHappened)
                return false;
        if (MoneyManager.amount < minIncome )
            return false;
        //checks for all required previous events weather they have happenedyet and if the rght choices were made
        foreach (EventObject previousEvent in previousEventsSecondOption) 
            if (!previousEvent.SecondOptionSelected)
                return false;
        foreach (EventObject previousEvent in previousEventsFirstOption)
            if (previousEvent.SecondOptionSelected && !previousEvent.hasHappened)
                return false;
        return true;
    }

    // Start is called before the first frame update
    //add the event to the eventlist in the eventmanager
    void Start()
    {
        Add.Invoke();
    }
}