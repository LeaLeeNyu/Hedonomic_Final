using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipSpawnController : MonoBehaviour
{
    public int equipCount;
    private int equipCurrentCount = 0;
    [SerializeField]private GameObject equipP;

    //The simple interactable, when player select, spawn the equipment
    [SerializeField] private GameObject interactable;
    
    //For spawn eqipment in the world
    private GameObject xrOrigin;
    [SerializeField] private float Offset;

    //Interface
    [SerializeField] private TMP_Text equipamount;

    private void Start()
    {
        equipamount.text = (equipCount-equipCurrentCount).ToString();
    }

    public void SpawnEquip()
    {
        SpawnObject(equipP);
    }

    private void SpawnObject(GameObject equip)
    {      
        if (equipCurrentCount < equipCount)
        {
            xrOrigin = GameObject.Find("XR Origin");
            float spawnRad = Mathf.Deg2Rad * xrOrigin.transform.rotation.eulerAngles.y;
            Vector3 spawnPos = new Vector3(xrOrigin.transform.position.x + Offset * Mathf.Sin(spawnRad), 
                                           equip.transform.localScale.y/2, 
                                           xrOrigin.transform.position.z + Offset * Mathf.Cos(spawnRad));
            Quaternion spawnRot = Quaternion.LookRotation(spawnPos - xrOrigin.transform.position, Vector3.up);
            Quaternion spawnRotation = new Quaternion(equip.transform.rotation.x, spawnRot.y, equip.transform.rotation.z, equip.transform.rotation.w);
            Instantiate(equip, spawnPos, spawnRotation);
            equipCurrentCount += 1;
            equipamount.text = (equipCount - equipCurrentCount).ToString(); ;
        }       
    }

    private void Update()
    {
        //Set the interactable to false
        if(equipCurrentCount == equipCount)
        {
            //Need to change, when all the interactables out, its material should change, instead of disappare
            interactable.SetActive(false);
        }else if(equipCurrentCount < equipCount)
        {
            interactable.SetActive(true);
        }
    }
}
