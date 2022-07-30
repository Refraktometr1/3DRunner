using UnityEngine;
using Zenject;

public class ScriptableInstaller : MonoInstaller
{
    public ScriptableObject _playerResource;
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("AAAAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!!!");
        //Container.Bind<PlayerResourceStorage>().FromComponentOn( _playerResource).AsSingle().NonLazy();
    }
}