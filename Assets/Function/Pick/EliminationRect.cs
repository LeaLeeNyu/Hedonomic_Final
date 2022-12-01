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
    private readonly string[] materialNames = new string[5];
    private readonly int[] materialAmounts = new int[5];

    private void Start()
    {

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
        TimeLimitation.EndTimeEvent += SaveData;
    }

    private void OnDisable()
    {
        TimeLimitation.EndTimeEvent -= SaveData;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (TimeLimitation.start)
        {            
            if (other.gameObject.CompareTag("Box"))
            {
                Destroy(other.gameObject);
                box += 1;
            }
            if (other.gameObject.CompareTag("MoveUp"))
            {
                Destroy(other.gameObject);
                moveUp += 1;
            }
            if (other.gameObject.CompareTag("MoveForward"))
            {
                Destroy(other.gameObject);
                moveForward += 1;
            }
            if (other.gameObject.CompareTag("Rotate"))
            {
                Destroy(other.gameObject);
                rotate += 1;
            }
            if (other.gameObject.CompareTag("Stair"))
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
