using System;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public CinemachineVirtualCamera camera;
    private void Awake()
    {
        var _playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
        var activeCar = _playerCarsData.Cars.First(active => active.isActive == true);
        var player = Instantiate(activeCar.gameObject, Vector3.zero, Quaternion.identity);
        player.transform.parent = transform;
        camera.Follow = player.transform;
    }
}
