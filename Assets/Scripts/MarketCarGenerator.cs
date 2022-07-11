using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketCarGenerator : MonoBehaviour
{
    private PlayerCarsData _playerCarsData;
    private GameObject _carOnScene;
    
    void Start()
    {
        _playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
        //_carOnScene.GetComponent<MeshRenderer>().materials[0].
    }

    private void OnEnable()
    {
        //_carOnScene = Instantiate(_playerCarsData.Cars.);
    }
}
