using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

/*
 * To collect the building material that player collect
 */

public class EliminationRect : MonoBehaviour
{

    public SpawnMaterial mainSceneObject;

    [SerializeField] private BuildingMaterialSO box;
    [SerializeField] private BuildingMaterialSO rotate;
    [SerializeField] private BuildingMaterialSO moveUp;
    [SerializeField] private BuildingMaterialSO moveForward;
    [SerializeField] private BuildingMaterialSO stair;

    void OnTriggerEnter(Collider other)
    {
        if (TimeLimitation.start)
        {
            // Destroy(other.gameObject);

            if (other.gameObject.tag == "Box")
            {
                Destroy(other.gameObject);
                //box.amount += 1;
            }
            if(other.gameObject.tag == "MoveUp")
            {
                Destroy(other.gameObject);
                //moveUp.amount += 1;
            }
            if(other.gameObject.tag == "MoveForward")
            {
                Destroy(other.gameObject);
                //moveForward.amount += 1;
            }
            if(other.gameObject.tag == "Rotate")
            {
                Destroy(other.gameObject);
                //rotate.amount += 1;
            }
            if(other.gameObject.tag == "Stair")
            {
                Destroy(other.gameObject);
                //stair.amount += 1;
            }
        }

    }

}
