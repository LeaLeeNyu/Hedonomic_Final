using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterial : MonoBehaviour
{
    [SerializeField] private Transform plateformT;
    private GameObject[] XROrigin;

    private void Awake()
    {
        XROrigin = GameObject.FindGameObjectsWithTag("XROrigin");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CheckGround")
        {
            XROrigin[0].transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CheckGround")
        {
            //other.transform.parent.parent.SetParent(null) ;
            XROrigin[0].transform.SetParent(null);
        }
    }
}
