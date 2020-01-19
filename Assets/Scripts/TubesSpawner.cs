using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesSpawner : MonoBehaviour
{
    public GameObject tubePrefab;
    public Singleton  singleton;

    public float      offset;
    public float      spawnTime;
    public float      speed;
    public float      XcoordinateOfplayer;

    public bool       corrutineIsActive = false;

    void Update()
    {
        if(corrutineIsActive == false)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        corrutineIsActive = true;
        yield return new WaitForSeconds(spawnTime);
        CreateTube();
    }

    public void CreateTube()
    {
        GameObject tube = tubePrefab;
        Instantiate(tube, gameObject.transform);

        tube.transform.position = new Vector3(gameObject.transform.position.x, Random.Range(-offset, offset), 0);

        Tube tubeScript                = tube.GetComponent<Tube>();
        tubeScript.speed               = speed;
        tubeScript.XcoordinateOfplayer = XcoordinateOfplayer;
        tubeScript.singleton           = singleton;

        corrutineIsActive              = false;
    }
}
