using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParentTrigger : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private void OnCollisionEnter(Collision collision)
    {
        //if collision gameobject is xr origin
        if(collision.gameObject.layer == 6)
        {
            collision.gameObject.transform.parent = parent;
        }
    }
}
