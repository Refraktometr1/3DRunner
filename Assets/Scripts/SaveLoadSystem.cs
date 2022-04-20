using System;
using UnityEngine;
using System.IO;


public class SaveLoadSystem : MonoBehaviour
{
    private void Awake()
    {
        //var sc = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
       // sc.LoadData();
    }
    private void OnDisable()
    {
        var playerResourceStorage = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
        var playerData = Resources.Load<PlayerScriptableObject>("PlayerData");
        playerResourceStorage.Save();
        playerData.Save();
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            var playerResourceStorage = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
            var playerData = Resources.Load<PlayerScriptableObject>("PlayerData");
            playerResourceStorage.Save();
            playerData.Save();
        }
    }

    public static void SaveData<T>(T dataToSave, string nameSaveFile)
    {
        if (!Directory.Exists($"{Application.persistentDataPath}/Save"))
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/Save");
        }
        var path = $"{Application.persistentDataPath}/Save/{nameSaveFile}.json";
        string jsonData = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(path, jsonData);
    }
    
    public static void LoadScriptableObject(string fileName, object obj)
    {
        var jsonData = File.ReadAllText($"{Application.persistentDataPath}/Save/{fileName}.json");
        if (jsonData == "")
            Debug.Log("PlayerResourceStorage Load File Lost");
        
        JsonUtility.FromJsonOverwrite(jsonData, obj);
        Debug.Log($"{obj} is loaded");
    }
}
