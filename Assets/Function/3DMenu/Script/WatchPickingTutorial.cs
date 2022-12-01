using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchPickingTutorial : WatchPicking
{

    protected override void Update()
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
    }
}
