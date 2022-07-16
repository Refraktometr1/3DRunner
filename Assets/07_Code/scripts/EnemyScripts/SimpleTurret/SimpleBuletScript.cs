using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SimpleBuletScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float throwAngle;
    [SerializeField] private float timeOfLeave;
    [NonSerialized] public Vector3 goalPosition;
    private Vector3 direction;
    private Vector3 parabolaTarget;
    private Vector3 startPosition;
    private Vector3 controlPosition;
    private bool parabolla;

    private float flyTime;

    void OnEnable()
    {
        direction = Vector3.zero;
        StartCoroutine(TickForDeath());
    }

    void Update()
    {
        if(!parabolla)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            flyTime += Time.deltaTime;
            Vector3 m1 = Vector3.Lerp(startPosition, controlPosition, speed * Time.deltaTime + flyTime);
            Vector3 m2 = Vector3.Lerp(controlPosition, parabolaTarget, speed * Time.deltaTime + flyTime);
            transform.position = Vector3.Lerp(m1, m2, speed * Time.deltaTime + flyTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "LookZone")
            Destroy(gameObject);
    }

    public void SetDirection(Vector3 goal, bool p)
    {
        parabolla = p;
        if(!p)
        {
            direction = (goal - transform.position).normalized;
        }
        else
        {
            parabolaTarget = goal + Vector3.down * 2.0f;
            startPosition = transform.position;
            controlPosition = startPosition + (parabolaTarget - startPosition) / 2 + Vector3.up * 5.0f;
            flyTime = 0;
        }
    }

    private IEnumerator TickForDeath()
    {
        yield return new WaitForSeconds(timeOfLeave);
        Destroy(gameObject);
    }
}
