using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class BackToBase : MonoBehaviour
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
            SceneManager.LoadScene("Chengbo-Base-2");
            //SceneManager.LoadScene("Chengbo-PickUp-Final");

        }

    }

 }
