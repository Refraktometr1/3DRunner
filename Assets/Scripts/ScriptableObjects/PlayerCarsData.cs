using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerModelsCar", menuName = "ScriptableObjects/PlayerModelsCar") ]
public class PlayerModelsCar : ScriptableObject
{
    public List<PlayerModel> models;
}
