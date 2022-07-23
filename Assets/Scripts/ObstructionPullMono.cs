using System.Collections.Generic;
using UnityEngine;

public abstract class ObstructionPullMono : MonoBehaviour
{
    public GameObject prefabGameObject;
    private List<GameObject> _bonusObjects = new List<GameObject>();
    private int _index;
    public bool isBonus;
    public bool isStatic;
    public bool isFalling;
     
    void Start()
    {
       for (int i = 0; i < 10; i++)
       {
           var obstruction = Instantiate(prefabGameObject, Vector3.zero, Quaternion.identity);
           obstruction.transform.Rotate(0,180,0);
           obstruction.SetActive(false);
           _bonusObjects.Add(obstruction);
       }

       if (isBonus)
       {
           (ObstructionGenerator.ObstructionsBonus ??= new List<ObstructionPullMono>()).Add(this);
           return;
       }

       if (isStatic)
       {
           (ObstructionGenerator.StaticObstructions ??= new List<ObstructionPullMono>()).Add(this);
           return;
       }

       if (isFalling)
       {
           //(ObstructionGenerator.FallingObstructions ??= new List<ObstructionPullMono>()).Add(this);
       }
       
       (ObstructionGenerator.Obstructions ??= new List<ObstructionPullMono>()).Add(this);
       
    }

    public void SetObstruction(Vector3 position)
    {
        if ( _index == 9) 
            _index = 0;
        
        _bonusObjects[ _index].SetActive(true);
        _bonusObjects[_index].transform.position = position;
        _index++;
    }
}
