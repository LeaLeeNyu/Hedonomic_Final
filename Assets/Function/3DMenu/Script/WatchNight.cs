using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WatchNight : MonoBehaviour
{
    [SerializeField] private BuildingMaterialType materialType;
    [SerializeField] private TMP_Text materialAmount;
    [SerializeField] private TMP_Text cannotText;
    private int box, moveUp, moveForward, rotate, stair = 0;

    private void Start()
    {
        PlayerBagData bagData = SaveSystem.LoadBagData();

        if (materialType == BuildingMaterialType.Box && bagData.buildingMaterial.ContainsKey("Box"))
        {
            box = bagData.buildingMaterial["Box"];
            materialAmount.text = box.ToString();
        }else if(materialType == BuildingMaterialType.Rotate && bagData.buildingMaterial.ContainsKey("Rotate"))
        {
            rotate = bagData.buildingMaterial["Rotate"];
            materialAmount.text = rotate.ToString();
        }else if (materialType == BuildingMaterialType.MoveForward && bagData.buildingMaterial.ContainsKey("MoveForward"))
        {
            moveForward = bagData.buildingMaterial["MoveForward"];
            materialAmount.text = moveForward.ToString();
        }else if (materialType == BuildingMaterialType.MoveUp && bagData.buildingMaterial.ContainsKey("MoveUp"))
        {
            moveUp = bagData.buildingMaterial["MoveUp"];
            materialAmount.text = moveUp.ToString();
        }else if (materialType == BuildingMaterialType.Stair && bagData.buildingMaterial.ContainsKey("Stair"))
        {
            stair = bagData.buildingMaterial["Stair"];
            materialAmount.text = stair.ToString();
        }
        else
        {
            Debug.Log("The material data doesn't exist");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            cannotText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            cannotText.gameObject.SetActive(false);
        }
    }
}
