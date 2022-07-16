using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public PlayerInfo playerInfo;

    [SerializeField] private Image[] healthImages;
    [SerializeField] private int maxPlayerHealth;

    [SerializeField] private Text coinText;

    private void Start()
    {
        playerInfo.Health = maxPlayerHealth;
        playerInfo.coinNumber = 0;
        Cursor.visible = false;
    }

    public void testEvent()
    {
        Debug.Log("Pick something");
    }

    public void DecreaseHelth()
    {
        healthImages[playerInfo.Health].color = Color.gray;
    }

    public void IncreaseHealth()
    {
        playerInfo.Health++;
        if (playerInfo.Health > maxPlayerHealth) playerInfo.Health = maxPlayerHealth;
        healthImages[playerInfo.Health - 1].color = Color.red;
    }

    public void IncreaseCoin()
    {
        playerInfo.coinNumber++;
        coinText.text = playerInfo.coinNumber.ToString();
    }
}
