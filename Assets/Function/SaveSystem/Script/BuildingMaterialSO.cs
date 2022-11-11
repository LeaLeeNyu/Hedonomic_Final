using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingMaterialSO",menuName ="ScriptableObject/BuildingMaterial")]
public class BuildingMaterialSO:ScriptableObject
{
    public string id;
    public string description;
    public int amount;
}
