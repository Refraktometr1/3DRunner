using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    public static T Instanse { get; protected set; }

    private void Awake()
    {
        if (Instanse != null && Instanse != this)
        {
            Destroy(this);
            Debug.Log("An instance of this singleton already exists.");
        }
        else
        {
            Instanse = (T) this;
        }
    }
}
