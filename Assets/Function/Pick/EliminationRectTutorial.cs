using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;


public class EliminationRectTutorial : EliminationRect
{
    protected override void Start()
    {
        //Dont save material data for tutorial 
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Destroy(other.gameObject);
            box += 1;
        }
        if (other.gameObject.CompareTag("MoveUp"))
        {
            Destroy(other.gameObject);
            moveUp += 1;
        }
        if (other.gameObject.CompareTag("MoveForward"))
        {
            Destroy(other.gameObject);
            moveForward += 1;
        }
        if (other.gameObject.CompareTag("Rotate"))
        {
            Destroy(other.gameObject);
            rotate += 1;
        }
        if (other.gameObject.CompareTag("Stair"))
        {
            Destroy(other.gameObject);
            stair += 1;
        }
    }


}
