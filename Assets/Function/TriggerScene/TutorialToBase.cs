using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class TutorialToBase : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "LeftHand Direct" || other.gameObject.name == "RightHand Direct")
        {
            SceneManager.LoadScene("Chengbo-Base-1");
            //SceneManager.LoadScene("Chengbo-PickUp-Final");

        }

    }

 }
