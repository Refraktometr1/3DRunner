using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private Vector3 _newPositionTile;
    private Vector3 step = Vector3.forward*120;

   

    private void Update()
    {
        if (PlayerMoving.Instanse.transform.position.z - transform.position.z > 15)
        {
            _newPositionTile = transform.position + step;
            transform.position = _newPositionTile;
        }
    }
}
