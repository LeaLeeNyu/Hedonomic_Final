using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionTimer
{
    public float timer;
    public bool isDestoryed = false;

    public FunctionTimer(float timer,bool isDestoryed)
    {
        this.timer = timer;
        this.isDestoryed = isDestoryed;
    }

    public void UpdateTimer()
    {
        if (!isDestoryed)
        {
            timer -= Time.deltaTime;
            if (timer < 0.01f)
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