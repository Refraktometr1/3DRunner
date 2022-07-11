using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IResourceCollector
{
    private PlayerResourceStorage _playerResource;
    private AudioResources _audio;
    private PlayerScriptableObject _playerData;
    
    private void Awake()
    {
        _playerResource = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
        _audio = Resources.Load<AudioResources>("AudioResources");
        _playerData = Resources.Load<PlayerScriptableObject>("PlayerData");
    }

    public void Die()
    {
        AudioManager.Instanse.PlaySound(_audio.Die);
        _playerData.Speed = Vector3.zero;
        Debug.Log("Player Die");
    }

    public void Hit()
    {
        _playerResource.Money = (int)Mathf.Round(_playerResource.Money * 0.75f);
        Vibration.Vibrate(250,-1,true);
        AudioManager.Instanse.PlaySound(_audio.Hit);
        Debug.Log("Hit AAAA");
    }

    public void Collect(int value)
    {
        _playerResource.Money += value;
    }
}
