using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    //set the panel with the chosen event into the screen
    public UnityEvent ShowEvent { get { if (showEvent == null) showEvent = new UnityEvent(); return showEvent; } }
    [SerializeField] private UnityEvent showEvent;

    public List<EventObject> AllEvents; //list of all existing events
    public int PossibleEvents; //range of the id's of the events which requirments meet
    public static EventObject currentEvent; //the event that eventually was chosen to be shown
    

    //add event to the list of events
    public void AddEvent(EventObject eventObject)
    {
        AllEvents.Add(eventObject);
    }

    //on every 10th day check which events meet the requirements and pick one of these to show in the screen
    public void ManageEvents()//after each turn
    {
        if (DayCounter.dayCount % 10 == 0)
        {
            PossibleEvents = 0;
            foreach (EventObject eventObject in AllEvents)
            {
                if (eventObject.EventRequirementsMeet())
                {
                    eventObject.id = PossibleEvents;
                    PossibleEvents++;
                }
                else
                    eventObject.id = -1;
            }
            float max = (float)PossibleEvents - 1;
            int ChosenEvent = (int)(Random.Range(0f, max));
            currentEvent = AllEvents.Find(i => i.id == ChosenEvent);
            ShowEvent.Invoke();
        }
    }


    public void InvokeOption1() //when option 1 is chosen
    {
        currentEvent.Option1.Invoke();
    }
    
    public void eventConsequences(string consequences)
    {
        currentEvent.eventConsequences = consequences;
    }

    public void InvokeOption2()//when option 2 is chosen
    {
        currentEvent.Option2.Invoke();
    }
    
}
