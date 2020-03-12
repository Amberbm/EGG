using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Notificationmanager : MonoBehaviour
{
    public Text text;
    public string Consequences;

    void Update()
    {
        text.text = Consequences;
    }
    public void changeConsequences(string name)
    {
        Consequences = name;
    }

    public void ConsequencesMorality(string name, string negname)
    {
        if (Morality.value >= 0)
            Consequences = name;
        else
            Consequences = negname;
    }
}
