using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterial : MonoBehaviour
{
    [SerializeField] private Transform plateformT;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            other.transform.SetParent(transform);
            Debug.Log("player!");
        }

        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.SetParent(null) ;
        }
    }
}
