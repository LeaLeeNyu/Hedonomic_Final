using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MissionHandMaterial : MonoBehaviour
{
    [SerializeField]private XRSpawnInteractableFinal boxAmount;
    [SerializeField] private XRSpawnInteractableFinal moveUpAmount;
    [SerializeField] private XRSpawnInteractableFinal moveForwardAmount;
    [SerializeField] private XRSpawnInteractableFinal rotateAmount;
    [SerializeField] private XRSpawnInteractableFinal stairAmount;



    void Update()
    {
        if(MissionCompleteMaterialCount.countMaterial)
            MissionCompleteMaterialCount.surplusMaterial = boxAmount.equipAmount- boxAmount.equipCurrentCount
                                                     + moveUpAmount.equipAmount - moveUpAmount.equipCurrentCount
                                                     + moveForwardAmount.equipAmount - moveForwardAmount.equipCurrentCount
                                                     + rotateAmount.equipAmount - rotateAmount.equipCurrentCount
                                                     + stairAmount.equipAmount - stairAmount.equipCurrentCount;
    }


}
