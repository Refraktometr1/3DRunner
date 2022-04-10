using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class ObstructionGenerator : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _player;
    [SerializeField] private float _distanseBetwinObstruction;
    
   
    public static List<ObstructionPullMono> ObstructionsBonus;
    public static List<ObstructionPullMono> Obstructions;
    private Vector3 step = Vector3.right*50;
    private float _createObstructionPosition;

    private List<float> ShiftPosition = new List<float> {-3, 0, 3};


    private void Update()
    {
        if ( _player.Position.x - _createObstructionPosition > _distanseBetwinObstruction)
        {
            CreateObstruction();
            _createObstructionPosition = _player.Position.x;
        }
    }
  
    private void CreateObstruction()
    { 
        var position =  new Vector3((_player.Position.x + step.x), 0, ShiftPosition[Random.Range(0,3)]);

        bool isBonusGenerate = Random.Range(1, 101) % 10 == 0;
        if (isBonusGenerate)
        {
            ObstructionsBonus[0].SetObstruction(position);
            Debug.Log("Bonus");
        }
        else
        {
            Obstructions[Random.Range(0,Obstructions.Count)].SetObstruction(position); 
        }
    }
}
