using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterial : MonoBehaviour
{
    [SerializeField] private Transform plateformT;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CheckGround")
        {
            other.transform.parent.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CheckGround")
        {
            other.transform.parent.SetParent(null) ;
        }
    }
}
