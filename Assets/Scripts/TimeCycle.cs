using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour
{
    public static int min;
    public static float sec;
    public static int cycle;

    Text text;

    void Start()
    {
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

            min = 4;
            sec = 60;
            if (cycle == 1)
                cycle = 2;
            else if (cycle == 2)
                cycle = 1;
        }

        if (cycle == 1)
        {
            text.text = "Day remaining: " + min + ":" + sec;
        }
        else
        {
            text.text = "Night remaining: " + min + ":" + sec;
        }

    }


}
