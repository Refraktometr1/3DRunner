using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPickableCheck : MonoBehaviour
{
    [NonSerialized] public Vector3 playerPosition;

    [NonSerialized] public bool playerHere;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHere = true;
            playerPosition = other.gameObject.transform.position;
        }
    }
}
