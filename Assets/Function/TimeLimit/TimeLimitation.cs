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
    public static event UnityAction StartTimeEvent = delegate { };
    //The event that happen when time is up
    public static event UnityAction EndTimeEvent = delegate { };
    
    [SerializeField] private float time;
    private FunctionTimer timer;

    //start counting the spawning material time
    public static bool start = false;

    //time counter interface
    [HideInInspector]public static TMP_Text timeLimitationText;

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
        if (start && !timer.isDestoryed)
        {
            timer.UpdateTimer();
        }else if (start && timer.isDestoryed)
        {
            start = false;
            EndTimeEvent.Invoke();
            Debug.Log("End!");
        }

        //Time counter interface
        if(timeLimitationText != null)
        {
            float dicimalText = Mathf.Round(timer.timer * 100) / 100;

            if (dicimalText <= 0.01f)
                dicimalText = 0f;

            timeLimitationText.text = dicimalText.ToString();
        }
            
    }

    public void StartTime()
    {
        start = true;
        StartTimeEvent.Invoke();
    }


    
}
