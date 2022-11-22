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
    private string[] materialNames = new string[5];
    private int[] materialAmounts = new int[5];

    private void Start()
    {
        //Reset the data
        //SaveSystem.SaveBagData("Box", 0);
        //SaveSystem.SaveBagData("MoveUp", 0);
        //SaveSystem.SaveBagData("MoveForward", 0);
        //SaveSystem.SaveBagData("Rotate", 0);
        //SaveSystem.SaveBagData("Stair", 0);

        materialNames[0] = "Box";
        materialNames[1] = "MoveUp";
        materialNames[2] = "MoveForward";
        materialNames[3] = "Rotate";
        materialNames[4] = "Stair";

        for(int i = 0; i < materialAmounts.Length; i++)
        {
            materialAmounts[i] = 0;
        }

        SaveSystem.SaveBagData(materialNames, materialAmounts);

    }

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
        //SaveSystem.SaveBagData("Box", box);
        //SaveSystem.SaveBagData("MoveUp", moveUp);
        //SaveSystem.SaveBagData("MoveForward", moveForward);
        //SaveSystem.SaveBagData("Rotate", rotate);
        // SaveSystem.SaveBagData("Stair", stair);

        materialAmounts[0] = box;
        materialAmounts[1] = moveUp;
        materialAmounts[2] = moveForward;
        materialAmounts[3] = rotate;
        materialAmounts[4] = stair;

        SaveSystem.SaveBagData(materialNames, materialAmounts);

        Debug.Log("Save Bag Data");
    }

}
