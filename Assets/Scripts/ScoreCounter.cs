using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public int       currScore;
    public List<int> scorePoints;

    public Dictionary<string, int> scoreConteiner;

    public void Awake()
    {
        LoadScore();
        InitializationDictionary();
    }

    public void OnApplicationQuit()
    {
        SaveScore();
    }
    public void OnApplicationPause(bool pause)
    {
        SaveScore();
    }

    public void SaveScore()
    {
        InitializationDictionary();

        for (int i = 0; i < scoreConteiner.Count; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), scoreConteiner[i.ToString()]);
        }
    }

    public void LoadScore()
    {
        for (int i = 0; i < scorePoints.Count; i++)
        {
            scorePoints[i] = PlayerPrefs.GetInt(i.ToString());
        }
    }

    public void InitializationDictionary()
    {
        scoreConteiner = new Dictionary<string, int>
        {
            { "0", scorePoints[0] },
            { "1", scorePoints[1] },
            { "2", scorePoints[2] }
        };
    }

    public void AddScoreInList(int value)
    {
        if(scorePoints.Count < 3)
        {
            scorePoints.Add(value);
        }
        if(scorePoints.Count == 3)
        {
            int minValue = scorePoints.Min();

            if (minValue < value)
            {
                int index = scorePoints.IndexOf(minValue);
                scorePoints.Remove(scorePoints[index]);
                scorePoints.Add(value);
            }
        }

        SortingScoreList();
    }

    public void SortingScoreList()
    {
        scorePoints.Sort();
        scorePoints.Reverse();
    }

    public void ZeroingRating()
    {
        PlayerPrefs.DeleteAll();
    }

    public int biggestScore()
    {
        if(scorePoints.Count == 0)
        {
            return 0;
        }

        int maxValue = scorePoints.Max();
        return maxValue;
    }
}
