using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRHandControllerFinal : XRHandController
{
    [SerializeField]private Animator _animator;
    [SerializeField] private GameObject _glow;
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

            if (trigger >= 0.5f)
            {
                _glow.SetActive(true);
            }
            else
            {
                _glow.SetActive(false);
            }
        }
        else
        {
            _animator.SetFloat("Trigger", 0);
            _glow.SetActive(false);
        }
    }
}
