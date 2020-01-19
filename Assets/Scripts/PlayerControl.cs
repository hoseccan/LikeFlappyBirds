using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D       playerRigidbody;
    private GameObject        playerModel;
    private CapsuleCollider2D playerCollider;
    public  Singleton         singleton;
    private AudioSource       audio;

    public  float             forseOfJump;
    private Vector3           previousPos;
    private Vector3           currentPos;
    private Vector3           vectorOfSpeed;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerModel     = GetComponent<Transform>().GetChild(0).gameObject;
        playerCollider  = GetComponent<CapsuleCollider2D>();
        audio           = GetComponent<AudioSource>();
    }

    void Update()
    {
        Jump();
        RotateModel();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerRigidbody.AddForce(new Vector2(0, forseOfJump) * Time.deltaTime * 10000f);
            audio.Play();
        }
    }

    private void RotateModel()
    {
        Vector2 velocity = playerRigidbody.velocity;

        if ((velocity.y > 0) && (playerModel.transform.rotation.z > -30f) && (playerModel.transform.rotation.z <= 0))
        {
            playerModel.transform.Rotate(new Vector3(0, 0, 25f));
        }
        if ((velocity.y < 0) && (playerModel.transform.rotation.z < 30f) && (playerModel.transform.rotation.z >= 0))
        {
            playerModel.transform.Rotate(new Vector3(0, 0, -25f));
        }
    }

    public void OnCollisionEnter2D()
    {
        singleton.GameOver();
    }
}
