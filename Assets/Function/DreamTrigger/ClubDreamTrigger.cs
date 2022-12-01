using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClubDreamTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dreamAfter;
    [SerializeField] private string _dreamName;

    private bool showDream = false;


    //The platform that player stand on
    [SerializeField] private GameObject plateform;
    //move plateform
    [SerializeField] private float lerpSpeed;
    private float plateformMoveLerp;
    [SerializeField] private Vector3 _startPlateform;
    [SerializeField] private Vector3 _endPlateform;


    //The building
    [SerializeField] private GameObject dreamBuilding;
    //move building
    private float buildingMoveLerp;
    [SerializeField] private Vector3 _startBuilding;
    [SerializeField] private Vector3 _endBuilding;

    public static event UnityAction clubDreamTrigger = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _dreamName)
        {
            Destroy(other.gameObject);
            dreamAfter.SetActive(true);
            showDream = true;

            clubDreamTrigger.Invoke();
        }
    }

    private void Update()
    {
        if (showDream && plateformMoveLerp < 1)
        {
            plateformMoveLerp += lerpSpeed;
            MovePlateform(_startPlateform, _endPlateform, plateformMoveLerp);
        }

        if (showDream && buildingMoveLerp < 1)
        {
            buildingMoveLerp += lerpSpeed;
            MoveBuilding(_startBuilding, _endBuilding, buildingMoveLerp);
        }
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
