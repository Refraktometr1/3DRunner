using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 _firstPointOffset; 
    [SerializeField] private Vector3 _secondPointOffset; 
    
    private float _elapsedTime;
    

    public void MoveGameObject(GameObject gameObject, GameObject endPositionGO,  float animationTime)
    {
        StartCoroutine(AnimatorMove(gameObject, endPositionGO, animationTime));
    }
    
    private IEnumerator AnimatorMove(GameObject movedGameObject,  GameObject endPositionGO, float animationTime)
    {
        var startOffset = movedGameObject.transform.position - endPositionGO.transform.position;
        while (movedGameObject.transform.position != endPositionGO.transform.position)
        {
            _elapsedTime += Time.deltaTime;
            var percentageComplete =  _elapsedTime / animationTime;
            
            var firstApproximationPoint1 = Vector3.Lerp( endPositionGO.transform.position + startOffset, endPositionGO.transform.position + _firstPointOffset, curve.Evaluate(percentageComplete));
            var firstApproximationPoint2 = Vector3.Lerp( endPositionGO.transform.position + _firstPointOffset,endPositionGO.transform.position + _secondPointOffset, curve.Evaluate(percentageComplete));
            var firstApproximationPoint3 = Vector3.Lerp( endPositionGO.transform.position + _secondPointOffset,endPositionGO.transform.position, curve.Evaluate(percentageComplete));
            
            var secondApproximationPoint1 = Vector3.Lerp( firstApproximationPoint1,firstApproximationPoint2, curve.Evaluate(percentageComplete));
            var secondApproximationPoint2 = Vector3.Lerp( firstApproximationPoint2,firstApproximationPoint3, curve.Evaluate(percentageComplete));
            
            movedGameObject.transform.position = Vector3.Lerp(secondApproximationPoint1, secondApproximationPoint2, curve.Evaluate(percentageComplete));
            yield return null;
        }
        movedGameObject.SetActive(false);
        _elapsedTime = 0;
    }

    private Vector3 BezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1 - t;
        return 
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t  *p3;
    }

}
