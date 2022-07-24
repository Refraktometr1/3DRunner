using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPlayerTarget : MonoBehaviour
{
    [SerializeField] private UnityEvent playerStepOnZone;
    [SerializeField] private UnityEvent<Vector3> playerStillOnZone;
    [SerializeField] private UnityEvent playerLeaveZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            playerStepOnZone.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            playerStillOnZone.Invoke(other.gameObject.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            playerLeaveZone.Invoke();
    }
}
