using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePathMove : MonoBehaviour
{
    public List<Vector3> targetPoints;
    private int currentTarget;
    [SerializeField]
    public float speed;

    [SerializeField]
    private GameObject targetsRoot;

    [SerializeField]
    private bool oneDirection;

    [SerializeReference]
    private bool lookAtTarget;

    public Vector3 delta;

    void Start()
    {
        targetPoints = new List<Vector3>();
        currentTarget = 0;
        if (targetsRoot != null)
        {
            foreach (Transform target in targetsRoot.GetComponentInChildren<Transform>())
            {
                targetPoints.Add(target.position);
                Destroy(target.gameObject);
            }
            Destroy(targetsRoot);
        }
        else
        {
            foreach (Transform target in GetComponentInChildren<Transform>())
            {
                targetPoints.Add(target.position);
                Destroy(target.gameObject);
            }
        }
        currentTarget = 1;
    }

    void Update()
    {
        delta = MoveToTarget();
    }

    protected Vector3 MoveToTarget()
    {
        Vector3 delta = Vector3.MoveTowards(transform.position, targetPoints[currentTarget], speed * Time.deltaTime);
        Vector3 result = delta - transform.position;
        transform.position = delta;

        

        if (transform.InverseTransformPoint(targetPoints[currentTarget]) == Vector3.zero)
        {
            currentTarget++;
            if(lookAtTarget)
            {
                Quaternion currentRotation = transform.rotation;
                transform.LookAt(targetPoints[currentTarget]);
            }
            if (currentTarget >= targetPoints.Count)
            {
                if (oneDirection)
                {
                    transform.position = targetPoints[0];
                    currentTarget = 1;
                }
                else
                {
                    currentTarget = 0;
                }
            }
        }
        return result;
    }
}
