using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    private Vector2 _tileDimension = new Vector2(30,30);
    private const float _roadOffset = 20;
    private List<GameObject> _leftEnvironmentPool = new List<GameObject>();
    private List<GameObject> _rightEnvironmentPool = new List<GameObject>();
    private int _poolIndex;
    void Start()
    {
       GameObject LeftTilePrefab = Resources.Load<GameObject>("Prefabs/LeftEnvironmentTile");
       var RightTilePrefab = Resources.Load<GameObject>("Prefabs/RightEnvironmentTile");
       for (int i = 0; i < 5; i++)
       {
           Vector3 positionLeft = (Vector3.forward * _roadOffset)+(Vector3.right * ((i*_tileDimension.y)));
           Vector3 positionRight = (Vector3.back * _roadOffset)+(Vector3.right * ((i*_tileDimension.y)));
           var left = Instantiate(LeftTilePrefab, positionLeft, Quaternion.identity);
           var right = Instantiate(RightTilePrefab, positionRight, Quaternion.identity);
           _leftEnvironmentPool.Add(left);
           _rightEnvironmentPool.Add(right);
       }
    }
   
    void Update()
    {
        if ( PlayerMoving.Instanse.transform.position.x > _leftEnvironmentPool[_poolIndex].transform.position.x + 25)
        {
            var offset =  _leftEnvironmentPool[_poolIndex].transform.position.x + _tileDimension.x * (_leftEnvironmentPool.Count);
            _leftEnvironmentPool[_poolIndex].transform.position = Vector3.right*offset + Vector3.forward * _roadOffset;
            _rightEnvironmentPool[_poolIndex].transform.position = Vector3.right*offset + Vector3.back * _roadOffset;
            
            _poolIndex++;
            if (_poolIndex == _leftEnvironmentPool.Count)
                _poolIndex = 0;
        }
    }
    
    public static int RoundOff ( float i)
    {
        return ((int)Mathf.Floor(i / 10)) * 10;
    }
}
