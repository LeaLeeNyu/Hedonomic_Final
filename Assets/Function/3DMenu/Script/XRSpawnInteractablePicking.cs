using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSpawnInteractablePicking : XRSpawnInteractable
{
    [SerializeField] private int materialAmount;

    protected override void Start()
    {
        equipAmountText.text = (equipAmount - equipCurrentCount).ToString();
        equipAmount = materialAmount;
    }



}
