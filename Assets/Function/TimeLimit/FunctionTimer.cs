using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionTimer
{
    private UnityAction startAction;
    private UnityAction endAction;
    public float timer;
    private bool isDestoryed = false;

    public FunctionTimer(UnityAction startAction,UnityAction endAction, float timer)
    {
        this.startAction = startAction;
        this.endAction = endAction;
        this.timer = timer;
    }

    public void UpdateTimer()
    {
        if (!isDestoryed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //trigger the end action
                endAction.Invoke();
                DestorySelf();
            }
        }
    }

    private void DestorySelf()
    {
        isDestoryed = true;
        endAction.Invoke();
    }

    public void ResetSelf(float timer)
    {
        this.timer = timer;
        isDestoryed = false;
    }
}