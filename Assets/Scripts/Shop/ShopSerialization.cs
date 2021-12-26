using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ShopSerialization
{
    public void Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (Directory.Exists(Application.persistentDataPath + "/saves") == false)
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");

        string path = GetPath(saveName);
        FileStream file = File.Create(path);
        
        formatter.Serialize(file, saveData);
        file.Close();
    }

    public object Load(string saveName)
    {
        string path = GetPath(saveName);
        
        if (File.Exists(GetPath(path)) == false)
            return null;

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat(e.ToString(), path);
            file.Close();
            return null;
        }
    }

    private BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }

    private string GetPath(string saveName)
    {
        return Application.persistentDataPath + "/saves/" + saveName + ".save";
    }
}