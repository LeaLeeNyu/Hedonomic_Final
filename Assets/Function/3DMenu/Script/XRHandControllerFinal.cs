using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRHandControllerFinal : XRHandController
{
    [SerializeField]private Animator _animator;
    protected override void Update()
    {
        base.Update();

        UpdateHandPos();
    }

    void UpdateHandPos()
    {

        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float grip))
        {
            _animator.SetFloat("Grab", grip);
        }
        else
        {
            _animator.SetFloat("Grab", 0);
        }

        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float trigger))
        {
            _animator.SetFloat("Trigger", trigger);
        }
        else
        {
            _animator.SetFloat("Trigger", 0);
        }
    }
}
