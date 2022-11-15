using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * To control when to start spwaning material 
 */
public class SpawnTimeController : MonoBehaviour
{
    [SerializeField]
    //For Test
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.tag == "SpawnSocket")
        {

        }
    }
}
