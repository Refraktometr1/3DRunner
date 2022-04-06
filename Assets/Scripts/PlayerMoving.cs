using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Vector3 speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed;
    }
}
