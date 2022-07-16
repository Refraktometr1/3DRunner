using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public Transform player;
    public Transform target;
    bool isCable = false;
 

    void FixedUpdate()
    {
        if (isCable)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, target.transform.position, Time.deltaTime * 13);
            //player.transform.Translate(Vector3.MoveTowards(targets[0].transform.position, targets[1].transform.position, Time.deltaTime * 13));
        }

        if (player.transform.position == target.transform.position)
        {
            isCable = false;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Enter");
        if(other.gameObject.tag == "Player")
        {
            isCable = true;
        }  
    }


}
