using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GeneralManager : MonoBehaviour
{
    
    //Event which is a collection of all methodes that needs to be called at each change
    public UnityEvent Changes { get { if (changes == null) changes = new UnityEvent(); return changes; } }
    [SerializeField] private UnityEvent changes;
    

    public void SetChanges() //with each change
    {
        Changes.Invoke();
    }
}
