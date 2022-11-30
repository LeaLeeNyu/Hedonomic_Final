using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AncientDreamTrigger : MonoBehaviour
{    
    [SerializeField] private GameObject statueAfter;
    [SerializeField] private GameObject statueBefore;
    [SerializeField] private string _dreamName;

    private bool showDream = false;


    //The platform that player stand on
    [SerializeField] private GameObject plateform;
    [SerializeField] private GameObject plateformMesh;
    //move plateform
    [SerializeField] private float lerpSpeed;
    private float plateformMoveLerp;
    [SerializeField] private Vector3 _startPlateform;
    [SerializeField] private Vector3 _endPlateform;


    //The city
    [SerializeField] private GameObject dreamBuilding;
    //move city
    private float cityMoveLerp;
    [SerializeField] private Vector3 _startCity;
    [SerializeField] private Vector3 _endCity;

    public static event UnityAction ancientDreamTrigger = delegate { };

    private void Start()
    {
        //_dreamBuilding.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _dreamName)
        {
            Destroy(other.gameObject);
            statueAfter.SetActive(true);
            statueBefore.SetActive(false);
            plateformMesh.SetActive(true);
            showDream = true;

            //show plateform 
            //plateformMesh.SetActive(true);

            ancientDreamTrigger.Invoke();
        }
    }

    private void Update()
    {
        if (showDream && plateformMoveLerp < 1)
        {
            plateformMoveLerp += lerpSpeed;
            MovePlateform(_startPlateform, _endPlateform, plateformMoveLerp);
        }

        if (showDream && cityMoveLerp < 1)
        {
            cityMoveLerp += lerpSpeed;
            MoveBuilding(_startCity, _endCity, cityMoveLerp);
        }

        //if (showDream && plateformMoveLerp < 1)
        //{
        //    cityMoveLerp += lerpSpeed;
        //    MovePlateform(_startCity, _endCity, cityMoveLerp, dreamBuilding);
        //}
    }

    public void MovePlateform(Vector3 startPos, Vector3 endPos, float lerp)
    {
        Vector3 movePosPlatrform = SmoothLerp(startPos, endPos, lerp);
        plateform.transform.position = movePosPlatrform;
    }

    public void MoveBuilding(Vector3 startPos, Vector3 endPos, float lerp)
    {
        Vector3 movePosBuilding = SmoothLerp(startPos, endPos, lerp);
        dreamBuilding.transform.position = movePosBuilding;
    }

    private Vector3 SmoothLerp(Vector3 startPos, Vector3 endPos, float lerpPercent)
    {
        return new Vector3(
            Mathf.SmoothStep(startPos.x, endPos.x, lerpPercent),
            Mathf.SmoothStep(startPos.y, endPos.y, lerpPercent),
            Mathf.SmoothStep(startPos.z, endPos.z, lerpPercent));
    }
}
