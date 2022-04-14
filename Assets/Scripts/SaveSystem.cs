using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.IO; 

[DefaultExecutionOrder(-10)]
public class SaveSystem : MonoBehaviour
{
    public static void SaveData<T>(T dataToSave, string nameSaveFile)
    {
        if (!Directory.Exists($"{Application.dataPath}/Save"))
        {
            Directory.CreateDirectory($"{Application.dataPath}/Save");
        }

        var path = $"{Application.dataPath}/Save/{nameSaveFile}.json";
        string jsonData = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(path, jsonData);
    }
    
    public static void LoadScriptableObject(string fileName, object obj)
    {
        var jsonData = File.ReadAllText($"{Application.dataPath}/Save/{fileName}.json");
        if (jsonData == "")
            Debug.Log("PlayerResourceStorage Load File Lost");
        
        JsonUtility.FromJsonOverwrite( jsonData, obj);
        Debug.Log($"{obj} is loaded");
    }
    


    private void OnDisable()
    {
        var resourceStorage = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
        SaveData<PlayerResourceStorage>(resourceStorage, "PlayerResourceStorage");
        var playerData = Resources.Load<PlayerResourceStorage>("PlayerData");
        SaveData(playerData, "PlayerData");
    }
}
