using Cinemachine;
using UnityEngine;
using Zenject;

public class ScriptableInstaller : MonoInstaller
{
    public PlayerResourceStorage PlayerResource;
    public GameObject CarPrefab;
    public GameObject StartPoint;
    public CinemachineVirtualCamera virtualCamera;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerResourceStorage>().FromResources("PlayerResourceStorage").AsSingle();
    }
}