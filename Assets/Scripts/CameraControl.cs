﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject player;

    public float speedH = 2f;
    public float speedV = 2f;
    public float xrot;

    private float yaw = 0f;
    private float pitch = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerControl>().gamePaused)
        {

        }
        else
        {
            RotateCamera();
            Vector3 campos = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
            transform.position = campos;            
        }
    }

    void RotateCamera()// camera rotation for first person
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (pitch < -10)
        {
            pitch = -10;
        }

        if (pitch > 10)
        {
            pitch = 10;
        }
        Vector3 rotateCamera = new Vector3(pitch, yaw, 0f);

        transform.eulerAngles = rotateCamera;
    }
}
