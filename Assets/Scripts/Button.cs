using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject currScreen;
    public GameObject targetScreen;

    public void SwitchScreen()
    {
        targetScreen.SetActive(true);
        currScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SwitchScreen();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        SwitchScreen();
    }

    public void ExitOnMenu()
    {
        GameObject.Find("GameLevel").SetActive(false);
        SwitchScreen();
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}
