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
       var LeftTilePrefab = Resources.Load<GameObject>("Prefabs/EnvironmentLeft");
       var RightTilePrefab = Resources.Load<GameObject>("Prefabs/EnvironmentRight");
       for (int i = 0; i < 5; i++)
       {
           Vector3 positionLeft = (Vector3.right * _roadOffset)+(Vector3.forward * ((i*_tileDimension.y)));
           Vector3 positionRight = (Vector3.left * _roadOffset)+(Vector3.forward * ((i*_tileDimension.y)));
           var right = Instantiate(RightTilePrefab, positionLeft, Quaternion.identity);
           var left = Instantiate(LeftTilePrefab, positionRight, Quaternion.identity);
           _leftEnvironmentPool.Add(left);
           _rightEnvironmentPool.Add(right);
       }
       
       var tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");
       for (int i = 0; i < 12; i++)
       {
           var tile = Instantiate(tilePrefab, Vector3.forward * i*10, Quaternion.identity);
       }
    }
   
    void Update()
    {
        if ( PlayerMoving.Instanse.transform.position.z > _leftEnvironmentPool[_poolIndex].transform.position.z + 25)
        {
            var offset =  _leftEnvironmentPool[_poolIndex].transform.position.z + _tileDimension.x * (_leftEnvironmentPool.Count);
            _leftEnvironmentPool[_poolIndex].transform.position = Vector3.forward*offset + Vector3.left * _roadOffset;
            _rightEnvironmentPool[_poolIndex].transform.position = Vector3.forward*offset + Vector3.right * _roadOffset;
            
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
