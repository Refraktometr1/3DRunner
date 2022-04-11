using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private Vector3 _newPositionTile;
    private Vector3 step = Vector3.right*90;
    private PlayerScriptableObject _playerPosition;

    private void Start()
    {
        _playerPosition = Resources.Load<PlayerScriptableObject>("PlayerData");
    }

    private void Update()
    {
        if ( _playerPosition.Position.x - transform.position.x > 15)
        {
            _newPositionTile = transform.position + step;
            transform.position = _newPositionTile;
        }
       
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if ( other.name == "Player")
    //     {
    //         _newPositionTile = transform.position + step;
    //         transform.position = _newPositionTile;
    //     }
    // }
}
