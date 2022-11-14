using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class XRDreamSpawnInteractable : XRSpawnInteractable
{
    //when the spawn dream grabbable object leave the canvas collider, and player grab the dream into canvas
    private bool spawnLeave = false;

    [SerializeField] private GameObject dreamCanvasObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DreamOne" && spawnLeave)
        {
            equipCount += 1;
            equipamount.text = (equipCount - equipCurrentCount).ToString();
            Destroy(other.gameObject);
            spawnLeave = false;
            dreamCanvasObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DreamOne")
        {
            spawnLeave = true;
            dreamCanvasObject.SetActive(false);
        }
    }


}
