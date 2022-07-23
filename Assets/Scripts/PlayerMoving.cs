using System.Collections;
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
            StartCoroutine(CorutineDoMove(transform.position + Vector3.right * 3, false));
        }
    }
    
    private void SwipeLeft()
    {
        
        if (transform.position.x > -3)
        {
            StartCoroutine(CorutineDoMove(transform.position + Vector3.left * 3 , true));
        }
    }

    private IEnumerator CorutineDoMove(Vector3 moveTo, bool isLeft)
    {
        var roadPosition = 0;
        if (moveTo.x > 2)
        {
            roadPosition = 3;
        }
        else if(moveTo.x < -2)
        {
            roadPosition = -3;
        }

        if (isLeft)
        {
            while (transform.position.x > roadPosition)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left*14, Time.deltaTime);
                yield return null;
            }
        }
        else 
        {
            while (transform.position.x < roadPosition)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right*14, Time.deltaTime);
                yield return null;
            }
        }
    }
}
