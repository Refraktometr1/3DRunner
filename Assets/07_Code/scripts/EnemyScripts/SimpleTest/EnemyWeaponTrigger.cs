using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWeaponTrigger : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] UnityEvent playerInAttackField;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInAttackField.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            weapon.SetActive(false);
    }
}
