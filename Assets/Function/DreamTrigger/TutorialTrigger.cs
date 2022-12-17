using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject guildCanvas;
    [SerializeField] private GameObject finishCanvas;
    [SerializeField] private GameObject dream;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DreamOne")
        {
            guildCanvas.SetActive(false);
            finishCanvas.SetActive(true);
            dream.SetActive(true);

            Destroy(other.gameObject);
        }
    }
}
