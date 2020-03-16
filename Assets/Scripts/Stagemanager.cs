using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagemanager : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(PropertyManager.UpgradeLevel == 0)
        {
            image1.SetActive(true);
            image2.SetActive(false);
        }
        else if(PropertyManager.UpgradeLevel == 1)
        {
            image1.SetActive(false);
            image2.SetActive(true);
        }
    }
}
