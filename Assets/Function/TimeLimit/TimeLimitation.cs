using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Control the starting and ending of collecting the building material 
 * Use Unity Action to invoke the responding method
 */

public class TimeLimitation : MonoBehaviour
{
    public static event UnityAction startTime = delegate { };
    public static event UnityAction endTime = delegate { };
    
    [SerializeField] private float time;
    private FunctionTimer timer;

    //start counting the spawning material time
    public static bool start = false;

    private void Awake()
    {
        timer = new FunctionTimer(startTime, endTime, time);
    }

    private void Update()
    {
        if (start)
        {
            timer.UpdateTimer();
        }
    }

    public void StartTime()
    {
        start = true;
        startTime.Invoke();
    }

    
}
