using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.name == "Player")
        {
            Debug.Log(other.gameObject.name);
        }

       
    }
}
