using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DreamTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _dream;
    [SerializeField] private GameObject _dreamObject;
    [SerializeField] private string _dreamName;

    private bool showDream = false;

    //move plateform
    [SerializeField] private float lerpSpeed;
    private float moveLerp;
    [SerializeField] private Vector3 _start;
    [SerializeField] private Vector3 _end;
    [SerializeField] private GameObject plateform;
    [SerializeField] private GameObject plateformMesh;

    private void Start()
    {
        _dream.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _dreamName)
        {
            Destroy(other.gameObject);
            _dream.SetActive(true);
            _dreamObject.SetActive(true);
            showDream = true;
            plateformMesh.SetActive(true);
        }
    }

    private void Update()
    {
        if (showDream && moveLerp < 1)
        {
            moveLerp += lerpSpeed;
            MovePlateform(_start, _end, moveLerp, plateform);
        }
    }

    public void MovePlateform(Vector3 startPos, Vector3 endPos, float lerp, GameObject plateform)
    {
        Vector3 movePos = SmoothLerp(startPos, endPos, lerp);
        plateform.transform.localPosition = movePos;
    }

    private Vector3 SmoothLerp(Vector3 startPos, Vector3 endPos, float lerpPercent)
    {
        return new Vector3(
            Mathf.SmoothStep(startPos.x, endPos.x, lerpPercent),
            Mathf.SmoothStep(startPos.y, endPos.y, lerpPercent),
            Mathf.SmoothStep(startPos.z, endPos.z, lerpPercent));
    }
}
