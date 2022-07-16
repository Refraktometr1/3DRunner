using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClimbSideTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent playerOnSide;
    [SerializeField] private UnityEvent playerLeaveSide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { playerOnSide.Invoke(); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") { playerLeaveSide.Invoke(); }
    }
}
