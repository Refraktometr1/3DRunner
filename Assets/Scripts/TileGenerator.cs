using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private Vector3 _newPositionTile;
    private Vector3 step = Vector3.right*80;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TileExit");

        _newPositionTile = transform.position + step;
        transform.position = _newPositionTile;
    }
}
