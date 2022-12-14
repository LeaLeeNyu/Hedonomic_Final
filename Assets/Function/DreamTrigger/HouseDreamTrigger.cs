using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseDreamTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dreamLight;
    [SerializeField] private string _dreamName;

    private bool showDream = false;

    //The platform that player stand on
    [SerializeField] private GameObject house;
    //move plateform
    [SerializeField] private float lerpSpeed;
    private float houseMoveLerp;
    [SerializeField] private Vector3 _startHouse;
    [SerializeField] private Vector3 _endHouse;

    public static event UnityAction houseDreamTrigger = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _dreamName)
        {
            Destroy(other.gameObject);
            dreamLight.SetActive(true);
            showDream = true;

            houseDreamTrigger.Invoke();
        }
    }

    private void Update()
    {
        if (showDream && houseMoveLerp < 1)
        {
            houseMoveLerp += lerpSpeed;
            MovePlateform(_startHouse, _endHouse, houseMoveLerp);
        }
    }

    public void MovePlateform(Vector3 startPos, Vector3 endPos, float lerp)
    {
        Vector3 movePosPlatrform = SmoothLerp(startPos, endPos, lerp);
        house.transform.position = movePosPlatrform;
    }


    private Vector3 SmoothLerp(Vector3 startPos, Vector3 endPos, float lerpPercent)
    {
        return new Vector3(
            Mathf.SmoothStep(startPos.x, endPos.x, lerpPercent),
            Mathf.SmoothStep(startPos.y, endPos.y, lerpPercent),
            Mathf.SmoothStep(startPos.z, endPos.z, lerpPercent));
    }
}
