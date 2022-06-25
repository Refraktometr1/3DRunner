using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CarModels", menuName = "ScriptableObjects/CarModels") ]
public class CarModelsScriptable : ScriptableObject
{
    public List<PlayerModel> models;
}
