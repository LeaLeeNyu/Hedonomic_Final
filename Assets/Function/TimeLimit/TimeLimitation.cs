using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
 * Control the starting and ending of collecting the building material 
 * Use Unity Action to invoke the responding method
 */

public class TimeLimitation : MonoBehaviour
{
    //The event that happen when time start
    public static event UnityAction startTime = delegate { };
    //The event that happen when time is up
    public static event UnityAction endTime = delegate { };
    
    [SerializeField] private float time;
    private FunctionTimer timer;

    //start counting the spawning material time
    public static bool start = false;

    //time counter interface
    [SerializeField] public Text timeCounter;

    private void Awake()
    {
        timer = new FunctionTimer(time);
    }

    private void Start()
    {
        StartTime();
    }

    private void Update()
    {
        if (start && timer!= null)
        {
            timer.UpdateTimer();
        }
        else if(start && timer == null)
        {
            start = false;
            endTime.Invoke();
        }

        //Time counter interface
        timeCounter.text = timer.timer.ToString();


    }

    public void StartTime()
    {
        start = true;
        startTime.Invoke();
    }


    
}
