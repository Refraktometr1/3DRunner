using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyResource : MonoBehaviour
{
    public PlayerResourceStorage _playerResource;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name != "Player")
            return;

        _playerResource.Money++;
        transform.gameObject.SetActive(false);
    }
}
