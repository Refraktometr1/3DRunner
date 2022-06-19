using UnityEngine;

public class PlayerMoving : MonoSingleton<PlayerMoving>,  IDamageable
{
    private Vector3 _touchStart;
    private Vector3 _swipeDistanse;
    private bool isDragging;
    public PlayerScriptableObject PlayerData;
    public PlayerResourceStorage PlayerResource;
    public AudioResources Audio;


    void FixedUpdate()
    { 
        transform.position +=  PlayerData.Speed;
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
    }

    private void Reset()
    {
            _touchStart = Vector3.zero;
            isDragging = false;
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

    public void Die()
    {
        AudioManager.Instanse.PlaySound(Audio.Die);
        PlayerData.Speed = Vector3.zero;
        Debug.Log("Player Die");
    }

    public void Hit()
    {
        PlayerResource.Money = (int)Mathf.Round(PlayerResource.Money * 0.75f);
        Vibration.Vibrate(250,-1,true);
        AudioManager.Instanse.PlaySound(Audio.Hit);
        Debug.Log("Hit AAAA");
    }
}
