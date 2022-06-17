using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyResource : MonoBehaviour
{
    public PlayerResourceStorage _playerResource;
    public int BonusValue;
    private AudioResources _audioResources;

    private void Start()
    {
        _audioResources =  Resources.Load<AudioResources>("AudioResources");
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name != "PlayerMainScene")
            return;
        AudioManager.Instanse.PlaySound(_audioResources.PickCoin);
        _playerResource.Money += BonusValue;
        transform.gameObject.SetActive(false);
    }
}
