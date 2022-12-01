using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRSpawnTutorial : XRSpawnInteractable
{
    [SerializeField] private WatchPicking watchPicking;

    private void Update()
    {
        equipAmount = watchPicking.materialAmount;
    }
}
