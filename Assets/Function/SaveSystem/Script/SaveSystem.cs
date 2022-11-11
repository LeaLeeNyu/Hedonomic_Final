using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem 
{
    public static void SavePlayerPos(CheckingPoint checkPoint)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerPosition.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerPositionData data = new PlayerPositionData(checkPoint);
        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerPositionData LoadPosData()
    {
        string path = Application.persistentDataPath + "/PlayerPosition.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerPositionData data = formatter.Deserialize(stream) as PlayerPositionData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No Data Record!");
            return null;
        }
    }
}
