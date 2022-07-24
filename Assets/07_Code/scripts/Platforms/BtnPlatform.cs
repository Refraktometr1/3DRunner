using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlatform : MonoBehaviour
{
    public GameObject platform;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon")
        {
            platform.GetComponent<MovingPlatform>().isMoving = true;
            transform.localRotation = Quaternion.Euler(0f, -42f, 0f);
        }
    }

}
