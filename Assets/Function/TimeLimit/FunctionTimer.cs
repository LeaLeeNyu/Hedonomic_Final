using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionTimer
{
    public float timer;
    private bool isDestoryed = false;

    public FunctionTimer(float timer)
    {
        this.timer = timer;
    }

    public void UpdateTimer()
    {
        if (!isDestoryed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                DestorySelf();
            }
        }
    }

    private void DestorySelf()
    {
        isDestoryed = true;
    }

    public void ResetSelf(float timer)
    {
        this.timer = timer;
        isDestoryed = false;
    }
}