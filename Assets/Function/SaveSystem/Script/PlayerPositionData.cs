using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPositionData
{
    public float[] position;
    public PlayerPositionData(CheckingPoint checkingPoint)
    {
        position = new float[3];
        position[0] = checkingPoint.checkPointPos.x;
        position[1] = checkingPoint.checkPointPos.y;
        position[2] = checkingPoint.checkPointPos.z;
    }
}
