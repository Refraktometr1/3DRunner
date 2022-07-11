using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerCar", menuName = "ScriptableObjects/PlayerCar") ]
public class PlayerModel : ScriptableObject
{
   public GameObject gameObject;
   public bool isOpen;
   public bool isActive;
   public int price;
   public string nameText;
   public int capacity;
   public Color bodyColor;
}
