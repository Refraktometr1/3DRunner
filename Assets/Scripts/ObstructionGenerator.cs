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
    private Vector3 step = Vector3.forward*50;
    private float _createObstructionPosition;

    private List<float> ShiftPosition = new List<float> {-3, 0, 3};


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
        var position =  new Vector3(ShiftPosition[Random.Range(0,3)], 0,(PlayerMoving.Instanse.transform.position.z + step.z));

        bool isBonusGenerate = Random.Range(1, 101) % 5 == 0;
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

    private void OnDisable()
    {
        Obstructions.Clear();
        ObstructionsBonus.Clear();
        _createObstructionPosition = 0f;
    }
}
