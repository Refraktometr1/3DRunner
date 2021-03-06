using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamageable, IResourceCollector
{
    private PlayerResourceStorage _playerResource;
    private AudioResources _audio;
    private PlayerScriptableObject _playerData;
    private BezierCurveAnimation _collectAnimator;

    
    public void Init(BezierCurveAnimation collectAnimator)
    {
        _collectAnimator = collectAnimator;
    }

    private void Awake()
    {
        _audio = Resources.Load<AudioResources>("AudioResources");
        _playerData = Resources.Load<PlayerScriptableObject>("PlayerData");
        _playerResource = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
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

    public void Collect(int value, GameObject collectableGameObject)
    {
        collectableGameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log(collectableGameObject.name);
        _collectAnimator.MoveGameObject(collectableGameObject, this.gameObject, 1f);
        _playerResource.Money += value;
    }
}
