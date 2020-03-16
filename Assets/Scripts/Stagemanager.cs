using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagemanager : MonoBehaviour
{
    public bool stage1, stage2;
    public GameObject image1;
    public GameObject image2;
    // Start is called before the first frame update
    void Start()
    {
        stage1 = true;
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MoneyManager.amount >= 20)
        {
            stage1 = false;
            stage2 = true;
        }
        if(stage1)
        {
            image1.SetActive(true);
            image2.SetActive(false);
        }
        else if(stage2)
        {
            image1.SetActive(false);
            image2.SetActive(true);
        }
    }
}
