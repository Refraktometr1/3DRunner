using System.Collections;
using UnityEngine;

public class TempPlatformController : MonoBehaviour
{
    [SerializeField] 
    private float timeToBrake;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(DestroyOnTime(timeToBrake));
        } 
    }

    IEnumerator DestroyOnTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        gameObject.SetActive(false);
    }
}
