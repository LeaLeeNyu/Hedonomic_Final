using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VisualScripting;


public enum BuildingMaterialType
{
    Box,
    Rotate,
    MoveUp,
    MoveForward,
    Stair,
}

public class XRWatchPicking : MonoBehaviour
{
    [SerializeField] private BuildingMaterialType materialType;
    [SerializeField] private TMP_Text materialAmountText;
    private int materialAmount;

    private EliminationRect eliminationRact;

    private void Start()
    {
        eliminationRact = GameObject.Find("Bag").GetComponent<EliminationRect>();
    }

    private void Update()
    {
        if (materialType == BuildingMaterialType.Box)
        {
            materialAmount = eliminationRact.box;
        }
        else if (materialType == BuildingMaterialType.Rotate)
        {
            materialAmount = eliminationRact.rotate;
        }
        else if (materialType == BuildingMaterialType.MoveUp)
        {
            materialAmount = eliminationRact.moveUp;
        }
        else if (materialType == BuildingMaterialType.MoveForward)
        {
            materialAmount = eliminationRact.moveForward;
        }
        else if (materialType == BuildingMaterialType.Stair)
        {
            materialAmount = eliminationRact.stair;
        }

        materialAmountText.text = materialAmount.ToString();
    }



}
