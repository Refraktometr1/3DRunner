using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class ObstructionGenerator : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _obstruction;
    private List<GameObject> _obstructionPull = new List<GameObject>();
    private Vector3 step = Vector3.right*50;

    private List<Vector3> ShiftPosition = new List<Vector3>
        {new Vector3(0, 0, -3), new Vector3(0, 0, 0), new Vector3(0, 0, 3)};

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var obstruction = Instantiate(_obstruction, Vector3.zero, Quaternion.identity);
            _obstructionPull.Add(obstruction);
        }

        GenerateObstruction();
    }

    private void GenerateObstruction()
    {
        StartCoroutine(CreateObstruction());
    }

    private IEnumerator CreateObstruction()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 9)
                i = 0;
            //_obstructionPull[i].SetActive(true);
            _obstructionPull[i].transform.position = _player.transform.position + step + ShiftPosition[Random.Range(0,3)];
            yield return new WaitForSeconds(3);
        }
        yield return null;
    }
}
