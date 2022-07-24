using UnityEngine;

public abstract class ReactivePlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                Action();
            }
        }

    protected abstract void Action();
}