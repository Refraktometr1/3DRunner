using System.Collections;
using UnityEngine;

public class PlayerMoving : MonoSingleton<PlayerMoving>
{
    private Vector3 _touchStart;
    private Vector3 _swipeDistanse;
    private bool _isDragging;
    private int _moveTo;
    
    public PlayerScriptableObject PlayerData;

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - _moveTo) < 0.1f)
        {
            transform.position +=  PlayerData.Speed;
        }
        else if (transform.position.x  > _moveTo)
        {
            transform.position =  transform.position + Vector3.left;
        }
        else if (transform.position.x  < _moveTo)
        {
            transform.position =  transform.position + Vector3.right;
        }
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
        if (_swipeDistanse.x < -40)
        {
            SwipeLeft();
            Reset();
        }

        if (_swipeDistanse.x > 40)
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
            _moveTo = (int)transform.position.x + 3;
        }
    }
    
    private void SwipeLeft()
    {
        
        if (transform.position.x > -3)
        {
            _moveTo = (int)transform.position.x - 3;
        }
    }
}
