using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Tag : MonoBehaviour
{
    //event to add tag to the list of all tags in the propertymanager
    public UnityEvent AddTag { get { if (addTag == null) addTag = new UnityEvent(); return addTag; } }
    [SerializeField] private UnityEvent addTag;

    public string tagName;
    public float InfluenceFactor =1;

    void Start()//at the start
    {
        AddTag.Invoke();
    }


}
    
