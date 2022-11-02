using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    //Normal State
    [SerializeField] private float normalScale;
    [SerializeField] private GameObject equipMesh;
    [SerializeField] private BoxCollider equipCollider;

    //On Watch
    //[SerializeField] private float onWatchScale;
    //[SerializeField] private GameObject onWatchCanvas;
    


    private void Update()
    {
        //To make equipment static
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    //public void ShowWatchInfo()
    //{
    //    equipMesh.transform.localScale = new Vector3(onWatchScale, onWatchScale, onWatchScale);
    //    equipCollider.size = Vector3.one * onWatchScale;
    //    onWatchCanvas.SetActive(true);
    //}

    //public void HideWatchInfo()
    //{
    //    equipMesh.transform.localScale = new Vector3(normalScale, normalScale, normalScale);
    //    equipCollider.size = Vector3.one * normalScale;
    //    onWatchCanvas.SetActive(false);
    //}
}
