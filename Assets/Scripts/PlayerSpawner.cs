using System;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSpawner : MonoBehaviour
{
    [FormerlySerializedAs("virtualCamera1")] public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        var _playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
        var activeCar = _playerCarsData.Cars.First(active => active.isActive == true);
        var player = Instantiate(activeCar.gameObject, Vector3.zero, Quaternion.identity);
        player.transform.parent = transform;
        virtualCamera.Follow = player.transform;
    }
}
