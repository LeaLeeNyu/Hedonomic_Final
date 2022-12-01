using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class XRDreamSpawnInteractable : XRSpawnInteractable
{
    //when the spawn dream grabbable object leave the canvas collider, and player grab the dream into canvas
    private bool spawnLeave = false;

    [SerializeField] private GameObject dreamCanvasObject;
    [SerializeField] private string dreamName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == dreamName && spawnLeave)
        {
            equipAmount += 1;
            equipAmountText.text = (equipAmount - equipCurrentCount).ToString();
            Destroy(other.gameObject);
            spawnLeave = false;
            dreamCanvasObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == dreamName)
        {
            spawnLeave = true;
            dreamCanvasObject.SetActive(false);
        }
    }


}
