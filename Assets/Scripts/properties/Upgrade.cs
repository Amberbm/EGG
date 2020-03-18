using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour
{
    public UnityEvent Add { get { if (add == null) add = new UnityEvent(); return add; } }
    [SerializeField] private UnityEvent add;

    public int upgradeLevel;
    public int price;
    public int Influence;
    public string upgradeName;
    public string Description;
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
