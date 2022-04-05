using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TileExit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TileEnter");
    }
}
