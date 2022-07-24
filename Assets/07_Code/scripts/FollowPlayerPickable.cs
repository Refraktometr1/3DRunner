using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowPlayerPickable : MonoBehaviour
{
    [SerializeField] private UnityEvent pickEvent;
    [SerializeField] private float speed;
    private PlayerPickableCheck check;

    private void Awake()
    {
        check = GetComponentInChildren<PlayerPickableCheck>();
    }

    private void Update()
    {
        if(check.playerHere)
        {
            transform.position = Vector3.MoveTowards(transform.position, check.playerPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
