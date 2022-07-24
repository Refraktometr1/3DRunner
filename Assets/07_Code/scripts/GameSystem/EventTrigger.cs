using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent[] playerTriggered;
    [SerializeField] private UnityEvent<Vector3> playerToStartPosition;

    [SerializeField] Transform playerStartPosition;
    private Vector3 vPlayerStartPosition;

    private void Awake()
    {
        vPlayerStartPosition = playerStartPosition.position;
        GameObject.Destroy(playerStartPosition.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(UnityEvent e in playerTriggered)
            {
                e.Invoke();
            }
            playerToStartPosition.Invoke(vPlayerStartPosition);
        }
    }
}
