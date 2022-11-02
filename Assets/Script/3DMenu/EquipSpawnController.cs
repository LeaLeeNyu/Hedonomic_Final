using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSpawnController : MonoBehaviour
{
    public int boxCount;
    private int boxCurrentCount = 0;
    [SerializeField]private GameObject boxP;

    [SerializeField] private GameObject interactable;

    public void SpawnBox()
    {
        SpawnEqip(boxP);
    }

    private void SpawnEqip(GameObject equip)
    {
        if (boxCurrentCount < boxCount)
        {
            Instantiate(equip);
            boxCurrentCount += 1;
        }       
    }

    private void Update()
    {
        if(boxCurrentCount == boxCount)
        {
            interactable.SetActive(false);
        }else if(boxCurrentCount < boxCount)
        {
            interactable.SetActive(true);
        }
    }
}
