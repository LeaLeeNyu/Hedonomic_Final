using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBagData 
{
    public Dictionary<string, int> buildingMaterial = new Dictionary<string, int>();

    public PlayerBagData(string[] materialNames, int[] materialAmounts)
    {
        //buildingMaterial.Add(materialName, materialAmount);
        for(int i = 0; i < materialNames.Length; i++)
        {
            buildingMaterial.Add(materialNames[i], materialAmounts[i]);
        }
    }
}
