using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public int            state = 1;

    public GameObject     activeIcon;
    public GameObject     deactiveIcon;

    public void Awake()
    {
        LoadState();
    }

    public void OnApplicationQuit()
    {
        SaveState();
    }

    public void OnApplicationPause(bool pause)
    {
        SaveState();
    }

    public void Switch()
    {
        if(state == 1)
        {
            activeIcon.SetActive(false);
            deactiveIcon.SetActive(true);

            state = 0;
            AudioListener.volume = state;
        }
        else
        {
            activeIcon.SetActive(true);
            deactiveIcon.SetActive(false);

            state = 1;
            AudioListener.volume = state;
        }
    }

    public void LoadState()
    {
        state = PlayerPrefs.GetInt("listener");
        AudioListener.volume = state;

        if (state > 0)
        {
            activeIcon.SetActive(true);
            deactiveIcon.SetActive(false);
        }
        else
        {
            activeIcon.SetActive(false);
            deactiveIcon.SetActive(true);
        }
    }

    public void SaveState()
    {
        PlayerPrefs.SetInt("listener",state);
    }
}
