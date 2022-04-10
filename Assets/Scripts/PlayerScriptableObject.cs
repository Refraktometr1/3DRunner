using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
   public Vector3 Speed;
   public Vector3 Position;

   private void OnEnable()
   {
      Speed = new Vector3	(0.05f,0,0);
   }
}
