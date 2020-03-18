using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Headline : MonoBehaviour
{
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } }
    [SerializeField] private UnityEvent add;

    public string title;
    public string tag;
    public float factor;

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
    
}
