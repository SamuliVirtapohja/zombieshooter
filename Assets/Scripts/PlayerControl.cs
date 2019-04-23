using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool gamePaused = false;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        LockMouse();
    }

    // Update is called once per frame
    void Update()
    {
        GameState();
        Movement();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        ParticleSystem gunfire = GameObject.FindGameObjectWithTag("GunFire").GetComponent<ParticleSystem>();
        gunfire.Play();

        GameObject barrelend = GameObject.FindGameObjectWithTag("Weapon");
        Debug.Log(Input.mousePosition);
    }

    void RotatePlayer() // rotate player according to maincamera
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    void Movement()// player movement
    {
        RotatePlayer();
        float moveHorizontally = Input.GetAxis("Horizontal");
        float moveVertically = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontally, 0 ,moveVertically);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    void GameState()// set gamestate and enable menu
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                gamePaused = false;
                Time.timeScale = 1;
            }
            else
            {
                gamePaused = true;
                Time.timeScale = 0;
            }                
        }       
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ReleaseMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
