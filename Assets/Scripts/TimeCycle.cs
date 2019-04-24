using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour
{
    GameObject[] spawnPoints;
    GameObject player;
    public GameObject zombieprefab;


    public static int min;
    public static float sec;
    public static int cycle;
    public static int wave = 0;
    public int zombies = 10;

    Text text;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        InvokeRepeating("Time", 1f, 1f);
    }


    void Awake()
    {
        text = GetComponent<Text>();
        min = 0;
        sec = 10;
        cycle = 1;
    }

    void Time()
    {
        
        sec= sec - 1;

        if (sec < 0 && min > 0)
        {

            min--;
            sec = 60;
        }


        else if (min == 0 && sec <= 0)
        {

            min = 1;
            sec = 60;
            if (cycle == 1)
            { 
                cycle = 2;
                wave++;
                spawn();
            }
        else if (cycle == 2)
        {
            cycle = 1;
            min = 0;
            sec = 30;
        }
        }

        if (cycle == 1)
        {
            text.text = "Day remaining: " + min + ":" + sec;
        }
        else
        {
            text.text = "Night remaining: " + min + ":" + sec + "         Wave: " + wave;
        }

    }

    void spawn()
    {
        for(int zombieamount = 0;zombieamount < zombies; zombieamount++)
        {
            var number = Random.Range(0, spawnPoints.Length);

            Instantiate(zombieprefab, spawnPoints[number].transform);
        }
    }
}
