using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerResourceStorage", menuName = "ScriptableObjects/PlayerResourceStorage") ]

public class PlayerResourceStorage : ScriptableObject
{
    public int Money;

    private void OnEnable()
    {
        Load();
    }

    public void Load()
    {
        SaveLoadSystem.LoadScriptableObject(name,this);
    }

    public void Save()
    {
        SaveLoadSystem.SaveData(this, name); 
    }
}

