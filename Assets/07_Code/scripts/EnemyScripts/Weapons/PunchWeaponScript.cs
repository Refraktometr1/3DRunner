using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchWeaponScript : MonoBehaviour
{
    [SerializeField] private Transform punchWeaponDistance;
    [SerializeField] private float punchAttackSpeed;

    public bool onPunch;

    private Vector3 punchStart;
    private Vector3 punchTarget;

    private DinamicPathMoveTriggered randomMove;

    private void Start()
    {
        onPunch = false;
        randomMove = GetComponent<DinamicPathMoveTriggered>();
    }

    private void Update()
    {
        if(onPunch)
        {
            Vector3 delta = Vector3.MoveTowards(transform.position, punchTarget, punchAttackSpeed * Time.deltaTime);
            transform.position = delta;
            if(transform.InverseTransformPoint(punchTarget) == Vector3.zero)
            {
                onPunch = false;
                transform.position = punchStart;
                randomMove.isMoving = true;
                punchStart = Vector3.zero;
            }
        }
    }

    public void SetPunch()
    {
        punchTarget = punchWeaponDistance.position;
        punchStart = transform.position;
        onPunch = true;
        randomMove.isMoving = false;
    }

    public void MoveDifference(Vector3 delta)
    {
        if(punchStart != Vector3.zero)
        {
            punchStart += delta;
        }
    }
}
