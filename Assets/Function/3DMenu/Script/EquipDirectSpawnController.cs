using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
Test:The equipments will spawn at the position of 3D panel
 */

public class EquipDirectSpawnController : MonoBehaviour
{

    public int equipCount;
    private int equipCurrentCount = 0;
    [SerializeField] private GameObject equipP;
    [SerializeField] private Transform spawnPos;

    //Interface
    [SerializeField] private TMP_Text equipamount;

    private void Start()
    {
        equipamount.text = (equipCount - equipCurrentCount).ToString();
    }

    public void SpawnEqip()
    {
        SpawnObject(equipP);
    }

    public void SpawnObject(GameObject equip)
    {
        if (equipCurrentCount < equipCount)
        {
            Instantiate(equip, spawnPos.position, equip.transform.rotation);
            equipCurrentCount += 1;
            equipamount.text = (equipCount - equipCurrentCount).ToString();
        }
    }

}
