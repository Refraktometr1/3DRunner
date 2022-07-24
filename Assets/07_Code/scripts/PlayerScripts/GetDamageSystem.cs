using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetDamageSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> GetDamageCallback;
    [SerializeField] private string weaponTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == weaponTag)
            GetDamageCallback.Invoke(1);
    }
}
