using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class ObstructionGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distanseBetwinObstruction = 10;
    [SerializeField] private GameObject _obstruction;
    private List<GameObject> _obstructionPull = new List<GameObject>();
    private Vector3 step = Vector3.right*50;
    private float _createObstructionPosition;
    private int _obstuctionIndex;

    private List<float> ShiftPosition = new List<float> {-3, 0, 3};

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var obstruction = Instantiate(_obstruction, Vector3.up, Quaternion.identity);
            obstruction.SetActive(false);
            _obstructionPull.Add(obstruction);
        }
    }

    private void Update()
    {
        if ( _player.transform.position.x - _createObstructionPosition > _distanseBetwinObstruction)
        {
            CreateObstruction();
            _createObstructionPosition = _player.transform.position.x;
        }
    }
  
    private void CreateObstruction()
    {
        if ( _obstuctionIndex == 9) 
            _obstuctionIndex = 0;
        
        _obstructionPull[ _obstuctionIndex].SetActive(true);
        
        _obstructionPull[_obstuctionIndex].transform.position = 
            new Vector3((_player.transform.position.x + step.x),
            _obstructionPull[_obstuctionIndex].transform.position.y,
            ShiftPosition[Random.Range(0,3)]);
        
        _obstuctionIndex++;
    }
}
