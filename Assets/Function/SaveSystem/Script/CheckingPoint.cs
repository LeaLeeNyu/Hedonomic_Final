using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingPoint : MonoBehaviour
{
    public Vector3 checkPointPos;

    private void Awake()
    {
        checkPointPos = transform.position; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            SaveSystem.SavePlayerPos(this);
        }
    }
}
