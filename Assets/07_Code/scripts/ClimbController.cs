using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public Vector3 minPoint;
    public Vector3 maxPoint;

    private float minX, maxX, minY, maxY, minZ, maxZ;

    [SerializeField]
    private Transform minTrigger;
    [SerializeField]
    private Transform maxTrigger;

    public ClimbController leftTarget;
    public ClimbController rightTarget;

    public bool isTop;

    public bool playerOnLeft = false;
    public bool playerOnRight = false;

    public Vector3 test;

    private void Start()
    {
        minPoint = minTrigger.position;
        maxPoint = maxTrigger.position;

        Destroy(minTrigger.gameObject);
        Destroy(maxTrigger.gameObject);

        minX = Mathf.Min(minPoint.x, maxPoint.x);
        maxX = Mathf.Max(minPoint.x, maxPoint.x);
        minY = Mathf.Min(minPoint.y, maxPoint.y);
        maxY = Mathf.Max(minPoint.y, maxPoint.y);
        minZ = Mathf.Min(minPoint.z, maxPoint.z);
        maxZ = Mathf.Max(minPoint.z, maxPoint.z);

        test = minPoint - maxPoint;
    }

    public Vector3 getPosition(Vector3 pp)
    {
        Vector3 v = (minPoint - maxPoint).normalized;
        Vector3 p = pp - minPoint;
        Vector3 p1 = Vector3.Project(p, v);
        return minPoint + p1;
    }

    public Vector3 setOnBounds(Vector3 pp)
    {
        pp.x = Mathf.Clamp(pp.x, minX, maxX);
        pp.y = Mathf.Clamp(pp.y, minY, maxY);
        pp.z = Mathf.Clamp(pp.z, minZ, maxZ);
        return pp;
    }

    public Vector3 moveNearEdge(Vector3 pp, float speed)
    {
        return pp + (maxPoint - minPoint).normalized * speed;
    }

    public void PlayerOnRight()
    {
        playerOnRight = true;
    }

    public void PlayerOnLeft()
    {
        playerOnLeft = true;
    }

    public void PlayerLeaveRight()
    {
        playerOnRight = false;
    }

    public void PlayerLeaveLeft()
    {
        playerOnLeft = false;
    }
}
