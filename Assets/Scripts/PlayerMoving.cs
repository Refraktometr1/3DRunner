using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Vector3 speed;
    
    public GameObject tile;

    private void Start()
    {
       
    }

    private void OnTriggerExit(Collider other)
    {
        var a = other.transform.position;
        Instantiate(tile, (a + (Vector3.right * 20)), Quaternion.identity);
        Debug.Log("AAAAAAAAAAA");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed;
    }
}
