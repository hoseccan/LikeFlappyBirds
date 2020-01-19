using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Singleton singleton;

    public  float speed;
    public  float XcoordinateOfplayer;
    private float timeToDestroy = 10f;

    private bool  scoreAlreadyUpdate = false;

    void Start()
    {
        Destroy(gameObject, timeToDestroy); 
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        if ((transform.position.x < XcoordinateOfplayer) && (scoreAlreadyUpdate == false))
        {
            singleton.AddScore();
            scoreAlreadyUpdate = true;
        }
    }
}
