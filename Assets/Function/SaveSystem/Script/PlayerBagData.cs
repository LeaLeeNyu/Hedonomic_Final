using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBagData 
{
    public Dictionary<string, int> buildingMaterial = new Dictionary<string, int>();

    public PlayerBagData(string materialName, int materialAmount)
    {
        buildingMaterial.Add(materialName, materialAmount);
    }
}
