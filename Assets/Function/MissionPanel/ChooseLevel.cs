using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseLevel : MonoBehaviour
{
    public static event UnityAction chooseAncient = delegate { };
    public static event UnityAction chooseClub = delegate { };
    public static event UnityAction chooseHouse = delegate { };


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AncientDream")
        {
            chooseAncient.Invoke();
        }else if(other.gameObject.tag == "ClubDream")
        {
            chooseClub.Invoke();
        }
        else if (other.gameObject.tag == "HouseDream")
        {
            chooseHouse.Invoke();
        }
    }
}
