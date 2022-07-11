using System.Linq;
using UnityEngine;

public class PlayerMoving : MonoSingleton<PlayerMoving>
{
    private Vector3 _touchStart;
    private Vector3 _swipeDistanse;
    private bool _isDragging;
    
    public PlayerScriptableObject PlayerData;

    void FixedUpdate()
    { 
        transform.position +=  PlayerData.Speed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             _isDragging = true;
             _touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        if (!_isDragging)
            return;

        _swipeDistanse = Input.mousePosition - _touchStart;
        if (_swipeDistanse.x < -50)
        {
            SwipeLeft();
            Reset();
        }

        if (_swipeDistanse.x > 50)
        {
            SwipeRight();
            Reset();
        }
    }

    private void Reset()
    {
            _touchStart = Vector3.zero;
            _isDragging = false;
    }

    private void SwipeRight()
    {
        if (transform.position.x < 3)
        {
            transform.position = transform.position + Vector3.right * 3;
        }
    }
    
    private void SwipeLeft()
    {
        if (transform.position.x > -3)
        {
            transform.position = transform.position + Vector3.left * 3;
        }
    }
}
