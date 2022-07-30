using System;
using System.ComponentModel;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerSpawner : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        var playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
        var activeCar = playerCarsData.Cars.FirstOrDefault(active => active.isActive == true);
        var player = Instantiate(activeCar.gameObject, Vector3.zero, Quaternion.identity) ?? throw new ArgumentNullException(nameof(activeCar));
        player.transform.parent = transform;
        virtualCamera.Follow = player.transform;
        PlayerFactory(player);
    }

    private void PlayerFactory(GameObject player)
    {
        var playerScript = CheckLinkedScript<Player>(player);
        CheckLinkedScript<PlayerMoving>(player);
        var animationScript = CheckLinkedScript<BezierCurveAnimation>(player);
        playerScript.Init(animationScript);
    }

    private T CheckLinkedScript<T>(GameObject gameObjectForCheck) where T: UnityEngine.Component
    {
        T playerScript = gameObjectForCheck.GetComponent<T>();
        if (playerScript == null)
        {
            playerScript = gameObjectForCheck.AddComponent<T>();
        }
        return playerScript;
    }
}
