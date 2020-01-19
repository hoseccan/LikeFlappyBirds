using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreShower : MonoBehaviour
{
    public  string       position;
    public  ScoreCounter counter;
    private Text         text;

    public void OnEnable()
    {
        text = GetComponent<Text>();
        text.text = counter.scoreConteiner[position].ToString();
    }
}
