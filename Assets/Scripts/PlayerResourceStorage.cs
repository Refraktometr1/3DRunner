using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerResourceStorage", menuName = "ScriptableObjects/PlayerResourceStorage") ]

public class PlayerResourceStorage : ScriptableObject
{
    public int Money;

    public void OnEnable() => SaveSystem.LoadScriptableObject("PlayerResourceStorage", this);
}

