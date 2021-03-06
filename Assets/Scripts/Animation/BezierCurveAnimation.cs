using System;
using System.Collections;
using UnityEngine;

public class BezierCurveAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private int _firstPointOffset = 5; 
    [SerializeField] private int _secondPointOffset = 5;
    [SerializeField] private Vector3 _startOffsetForGizmos;
    
    private float _elapsedTime;
    

    public void MoveGameObject(GameObject gameObject, GameObject endPositionGO,  float animationTime)
    {
        StartCoroutine(AnimatorMove(gameObject, endPositionGO, animationTime));
    }
    
    private IEnumerator AnimatorMove(GameObject movedGameObject,  GameObject endPositionGO, float animationTime)
    {
        var startOffset = movedGameObject.transform.position - endPositionGO.transform.position;
        _elapsedTime = 0;
        while (Vector3.SqrMagnitude(movedGameObject.transform.position - endPositionGO.transform.position) > 0.1f )
        {
            _elapsedTime += Time.deltaTime;
            var percentageComplete =  _elapsedTime / animationTime;

            var p1 = endPositionGO.transform.position + Vector3.up * _firstPointOffset;
            if (startOffset.x < 0)
            {
                p1 = endPositionGO.transform.position + Vector3.left * _firstPointOffset;
            }
            if (startOffset.x > 0)
            {
                p1 = endPositionGO.transform.position + Vector3.right * _firstPointOffset;
            }
            
           movedGameObject.transform.position = BezierCurvePoint
                                                (endPositionGO.transform.position + startOffset,
                                                    p1,
                                                    endPositionGO.transform.position + Vector3.up * _secondPointOffset,
                                                    endPositionGO.transform.position,
                                                    percentageComplete
                                                );
            yield return null;
        }
        movedGameObject.SetActive(false);
        _elapsedTime = 0;
    }

    private Vector3 BezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        return
            Mathf.Pow(1 - t,3) * p0 +
            3f *  Mathf.Pow(1 - t,2) * t * p1 +
            3f * (1 - t) * t * t * p2 +
            t * t * t * p3;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (float i = 0; i < 1; i+= 0.05f)
        {
            var p1 = transform.position + Vector3.up * _firstPointOffset;
            if (_startOffsetForGizmos.x < 0)
            {
                p1 = transform.position + Vector3.left * _firstPointOffset;
            }
            if (_startOffsetForGizmos.x > 0)
            {
                p1 = transform.position + Vector3.right * _firstPointOffset;
            }
            
            var position = BezierCurvePoint(
                transform.position + _startOffsetForGizmos,
                p1,
                transform.position + Vector3.up * _secondPointOffset,
                transform.position,
                i);
            Gizmos.DrawSphere(position, 0.15f);
        }
    }
#endif
   
}
