using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRDreamGrabbable : XREquipGrabbableHand
{
    [SerializeField] private BuildingMaterialSO dreamOne;

    public static event UnityAction dreamOneActive = delegate { };

    //Dream could put back to watch canvas
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dream1Canvas" )
        {
            if(dreamOne.amount<1)
                dreamOne.amount += 1;

            Destroy(this.gameObject);       
        }else if(collision.gameObject.tag == "Dream1Socket" )
        {
            dreamOneActive.Invoke();
            Destroy(this.gameObject);
        }
    }
}
