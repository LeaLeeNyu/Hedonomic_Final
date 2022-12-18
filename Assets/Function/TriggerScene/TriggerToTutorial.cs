using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerToTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand" || other.tag == "RightHand")
        {
            SceneManager.LoadScene("Chengbo-Tutorial");
        }
    }
}
