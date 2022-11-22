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
    public int box, moveUp, moveForward, rotate, stair = 0;

    private void OnEnable()
    {
        TimeLimitation.endTime += SaveData;
    }

    private void OnDisable()
    {
        TimeLimitation.endTime -= SaveData;
    }

    void OnTriggerEnter(Collider other)
    {
        if (TimeLimitation.start)
        {            
            if (other.gameObject.tag == "Box")
            {
                Destroy(other.gameObject);
                box += 1;
            }
            if(other.gameObject.tag == "MoveUp")
            {
                Destroy(other.gameObject);
                moveUp += 1;
            }
            if(other.gameObject.tag == "MoveForward")
            {
                Destroy(other.gameObject);
                moveForward += 1;
            }
            if(other.gameObject.tag == "Rotate")
            {
                Destroy(other.gameObject);
                rotate += 1;
            }
            if(other.gameObject.tag == "Stair")
            {
                Destroy(other.gameObject);
                stair += 1;
            }
        }

    }

    void SaveData()
    {
        SaveSystem.SaveBagData("Box", box);
        SaveSystem.SaveBagData("MoveUp", moveUp);
        SaveSystem.SaveBagData("MoveForward", moveForward);
        SaveSystem.SaveBagData("Rotate", rotate);
        SaveSystem.SaveBagData("Stair", stair);
    }

}
