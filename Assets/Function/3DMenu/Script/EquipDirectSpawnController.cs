using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
Test:The equipments will spawn at the position of 3D panel
 */

public class EquipDirectSpawnController : MonoBehaviour
{

    private int equipCount;
    private int equipCurrentCount = 0;
    public BuildingMaterialSO buildingMaterial;
    [SerializeField] private GameObject equipP;
    [SerializeField] private Transform spawnPos;

    //Interface
    [SerializeField] private TMP_Text equipamount;

    private void Start()
    {
        equipCount = buildingMaterial.amount;
        equipamount.text = (equipCount - equipCurrentCount).ToString();
    }

    public void SpawnEqip()
    {
        SpawnObject(equipP);
    }

    private void SpawnObject(GameObject equip)
    {
        if (equipCurrentCount < equipCount)
        {
            Instantiate(equip, spawnPos.position, equip.transform.rotation);
            equipCurrentCount += 1;
            equipamount.text = (equipCount - equipCurrentCount).ToString();
        }
    }


    public void DebugLog()
    {
        Debug.Log("Select");
    }

}
