using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpavner : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        var _playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
        var activeCar = _playerCarsData.Cars.First(_active => _active.isActive == true);
        var player  =Instantiate(activeCar.gameObject, Vector3.zero, Quaternion.identity);
        player.transform.parent = transform;
    }
}
