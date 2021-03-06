﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagament : MonoBehaviour
{
    static bool firstime;
    public void StartGame()
    {
        if (!firstime)
        {
            SceneManager.LoadScene("Intro");
            firstime = true;
        }
        else
            SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Starting scene");
    }

    public void EndGame()
    {
        if(DayCounter.dayCount == 20)
        {
            if (MoneyManager.amount >= 1000)
                SceneManager.LoadScene("GoodEnd scene");
            if (MoneyManager.amount < 1000)
                SceneManager.LoadScene("BadEnd scene");
        }
    }
}
