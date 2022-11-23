using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class XRSpawnInteractableFinal : XRSpawnInteractable
{
    [SerializeField] private BuildingMaterialType materialType;
    protected override void Start()
    {
        PlayerBagData bagData = SaveSystem.LoadBagData();

        if (materialType == BuildingMaterialType.Box && bagData.buildingMaterial.ContainsKey("Box"))
        {
            equipAmount = bagData.buildingMaterial["Box"];
        }
        else if (materialType == BuildingMaterialType.Rotate && bagData.buildingMaterial.ContainsKey("Rotate"))
        {
            equipAmount = bagData.buildingMaterial["Rotate"];
        }
        else if (materialType == BuildingMaterialType.MoveForward && bagData.buildingMaterial.ContainsKey("MoveForward"))
        {
            equipAmount = bagData.buildingMaterial["MoveForward"];
        }
        else if (materialType == BuildingMaterialType.MoveUp && bagData.buildingMaterial.ContainsKey("MoveUp"))
        {
            equipAmount = bagData.buildingMaterial["MoveUp"];
        }
        else if (materialType == BuildingMaterialType.Stair && bagData.buildingMaterial.ContainsKey("Stair"))
        {
            equipAmount = bagData.buildingMaterial["Stair"];
        }
        else
        {
            Debug.Log("The material data doesn't exist");
        }

        equipAmountText.text = (equipAmount - equipCurrentCount).ToString();
    }
}
