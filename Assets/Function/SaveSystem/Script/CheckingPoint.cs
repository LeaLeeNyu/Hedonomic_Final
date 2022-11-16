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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            SaveSystem.SavePlayerPos(this);
        }
    }

}
