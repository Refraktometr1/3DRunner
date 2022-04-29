using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class ObstructionGenerator : MonoBehaviour
{
    [SerializeField] private float _distanseBetwinObstruction;
   
    public static List<ObstructionPullMono> ObstructionsBonus;
    public static List<ObstructionPullMono> Obstructions;
    public static List<ObstructionPullMono> StaticObstructions;
    private Vector3 step = Vector3.forward*50;
    private float _createObstructionPosition;
    private int _banStatic = 0;
    private int? _banRoadPositionIndex = null;

    private List<int> _roadPosition = new List<int> {-3, 3, 0};


    private void Update()
    {
        if (PlayerMoving.Instanse.transform.position.z - _createObstructionPosition > _distanseBetwinObstruction)
        {
            CreateObstruction();
            _createObstructionPosition = PlayerMoving.Instanse.transform.position.z;
        }
    }
  
    private void CreateObstruction()
    {

        var roadPositionIndex = Random.Range(0, 3);
        bool isBonusGenerate = Random.Range(1, 101) % 5 == 0;
        
        if (roadPositionIndex == _banRoadPositionIndex && isBonusGenerate == false)
        {
            roadPositionIndex = roadPositionIndex == 1 ?  0 : 1;
        }
        var position =  new Vector3(_roadPosition[roadPositionIndex], 0,(PlayerMoving.Instanse.transform.position.z + step.z));
        
        if (isBonusGenerate)
        {
            ObstructionsBonus[0].SetObstruction(position);
            return;
        }

        if (_banStatic > 0)
        {
            Obstructions[Random.Range(0,Obstructions.Count)].SetObstruction(position);
            if (_banStatic == 1)
                _banRoadPositionIndex = null;
            
            _banStatic--;
            return;
        }
        
        bool isStaticObstructions = Random.Range(1, 101) > 70;
        if (isStaticObstructions)
        {
            _banStatic = 5;
            if (position.x == 0)
                position.x = _roadPosition[Random.Range(0, 1)];
           
            StaticObstructions[Random.Range(0,StaticObstructions.Count)].SetObstruction(position);
            _banRoadPositionIndex = _roadPosition.IndexOf((int)position.x);
        }
        else
        {
            Obstructions[Random.Range(0,Obstructions.Count)].SetObstruction(position); 
        }
    }

    private void OnDisable()
    {
        Obstructions.Clear();
        ObstructionsBonus.Clear();
        StaticObstructions.Clear();
        _createObstructionPosition = 0f;
    }
}
