using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMove : MonoBehaviour
{
    private int _speed = 10;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
