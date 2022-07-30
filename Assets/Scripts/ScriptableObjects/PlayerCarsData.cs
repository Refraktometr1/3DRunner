using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerCarsData", menuName = "ScriptableObjects/PlayerCarsData") ]
public class PlayerCarsData : ScriptableObject
{
    public List<PlayerModel> Cars;
}
