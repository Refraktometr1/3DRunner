using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMoving : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 _touchStart;
    public Vector3 _swipeDistanse;
    private Time _startSwipeTime;
    private bool isDragging;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            _touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
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

        if (isDragging)
        {
            _swipeDistanse = Input.mousePosition - _touchStart;
            if (_swipeDistanse.x < -50 )
            {
                SwipeLeft();
                Reset();
            }

            if (_swipeDistanse.x > 50 )
            {
                SwipeRight();
                Reset();
            }
        }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     if (Camera.main.ScreenToWorldPoint(Input.mousePosition).z > transform.position.z)
        //     {
        //         MoveRight
        //     } = ;
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
        speed = Vector3.zero;
        Debug.Log("Player Die");
    }
}
