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
    private bool isDestory = false;

    //start counting the spawning material time
    public static bool start = false;

    //time counter interface
    [HideInInspector]public static TMP_Text timeLimitationText;

    private void Awake()
    {
        timer = new FunctionTimer(time, isDestory);
    }

    private void Start()
    {
        StartTime();
    }

    private void Update()
    {
        if (start && !isDestory)
        {
            timer.UpdateTimer();
        }
       
        if(start && isDestory)
        {
            start = false;
            endTime.Invoke();
            Debug.Log("End!");
        }

        //Time counter interface
        if(timeLimitationText != null)
            timeLimitationText.text = timer.timer.ToString();
    }

    public void StartTime()
    {
        start = true;
        startTime.Invoke();
    }


    
}
