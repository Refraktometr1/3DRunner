using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
   public Vector3 Speed;

   private void OnEnable()
   {
       SaveSystem.LoadScriptableObject("PlayerData", this);
   }

   // private void OnDestroy()
   // {
   //    SaveSystem.SaveData(this, name);
   // }
}
