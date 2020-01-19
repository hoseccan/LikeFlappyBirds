using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject level;
    public GameObject gameScreen;

    void OnEnable()
    {
        Invoke("StartGameAfterIntro", 2f);
    }

    void StartGameAfterIntro()
    {
        gameScreen.SetActive(true);
        gameObject.SetActive(false);
        level.SetActive(true);
    }
}
