using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private PlayerResourceStorage _playerResourceStorage;
    private void Awake()
    {
        _playerResourceStorage = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name != "Player")
         return;

        if (transform.position.x - other.transform.position.x > 1)
        {
            other.GetComponent<PlayerMoving>().Die();
        }
        else
        {
            other.GetComponent<PlayerMoving>().Hit();
            _playerResourceStorage.Money = (int)Math.Round(_playerResourceStorage.Money * 0.75f);
        }
    }
}
