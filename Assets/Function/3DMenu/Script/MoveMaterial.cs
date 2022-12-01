using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterial : MonoBehaviour
{
    [SerializeField] private Transform plateformT;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.transform.SetParent(transform);
            Debug.Log("player!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.transform.SetParent(null) ;
        }
    }
}
