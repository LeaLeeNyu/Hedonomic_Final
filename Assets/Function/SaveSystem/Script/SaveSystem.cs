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

    public static void SaveBagData(string[] materialNames, int[] materialAmounts)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/BagData.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerBagData data = new PlayerBagData(materialNames, materialAmounts);
        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerPositionData LoadPosData()
    {
        string path = Application.persistentDataPath + "/PlayerPosition.game";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
           
            PlayerPositionData data = formatter.Deserialize(stream) as PlayerPositionData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No Location Data Record!");
            return null;
        }
    }

    public static PlayerBagData LoadBagData()
    {
        string path = Application.persistentDataPath + "/BagData.game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerBagData data = formatter.Deserialize(stream) as PlayerBagData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No Bag Data Record!");
            return null;
        }
    }
}
