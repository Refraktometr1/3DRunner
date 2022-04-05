using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionGenerator : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _obstruction;
    private List<GameObject> _obstructionPull = new List<GameObject>();
    private Vector3 step = Vector3.right*50;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var obstruction = Instantiate(_obstruction, Vector3.zero, Quaternion.identity);
            obstruction.SetActive(false);
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
            
            _obstructionPull[i].SetActive(true);
            _obstructionPull[i].transform.position = _player.transform.position + step;
            yield return new WaitForSeconds(3);
            
        }
        yield return null;
    }
}
