using System;
using UnityEngine;

public class PlayerMoving : MonoSingleton<PlayerMoving>
{
    public Vector3 _touchStart;
    public Vector3 _swipeDistanse;
    private bool isDragging;
    public PlayerScriptableObject PlayerData;

    void FixedUpdate()
    { 
        transform.position +=  PlayerData.Speed;
    }

    private void Update()
    {
        // Ray rey = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(rey, out RaycastHit reycastHit))
        // {
        //     if (3 >= reycastHit.point.z && reycastHit.point.z>= -3f)
        //     {
        //         var posinion  = transform.position;
        //         posinion.z = reycastHit.point.z;
        //         transform.position = posinion;
        //     }
        // }
        if (Input.GetMouseButtonDown(0))
        {
             isDragging = true;
             _touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        if (!isDragging)
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
        
        
        // if (Input.touchCount > 0)
        // {
        //     if (Input.touches[0].phase == TouchPhase.Began)
        //     {
        //         _tap = true;
        //         isDragging = true;
        //         _touchStart = Input.touches[0].position;
        //     }
        //     else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        //     {
        //         Reset();
        //     }
        // }
    }

    private void Reset()
    {
            _touchStart = Vector3.zero;
            isDragging = false;
    }

    private void SwipeRight()
    {
        if (transform.position.z > -3)
        {
            transform.position = transform.position + Vector3.back * 3;
        }
        Debug.Log("SwipeRight");
    }
    
    private void SwipeLeft()
    {
        if (transform.position.z < 3)
        {
            transform.position = transform.position - Vector3.back * 3;
        }
        Debug.Log("SwipeLeft");
    }

    public void Die()
    {
        PlayerData.Speed = Vector3.zero;
        Debug.Log("Player Die");
    }

    public void Hit()
    {
        Debug.Log("Hit AAAA");
    }
}
