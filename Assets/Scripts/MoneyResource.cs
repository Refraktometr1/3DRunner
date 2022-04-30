using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyResource : MonoBehaviour
{
    public PlayerResourceStorage _playerResource;
    public int BonusValue;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name != "Player")
            return;

        _playerResource.Money += BonusValue;
        transform.gameObject.SetActive(false);
    }
}
