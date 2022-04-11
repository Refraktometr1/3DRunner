using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounterUI : MonoBehaviour
{
    public TextMeshProUGUI _moneyCounter;
    private PlayerResourceStorage _playerResourceStorage;
    private int _moneyCounterPreviosFrame;
    void Start()
    {
        _playerResourceStorage = Resources.Load<PlayerResourceStorage>("PlayerResourceStorage");
        _moneyCounter.text = $"Money: {_playerResourceStorage.Money.ToString()}";
    }

    void Update()
    {
        if (_playerResourceStorage.Money != _moneyCounterPreviosFrame)
        {
            _moneyCounter.text = $"Money: {_playerResourceStorage.Money.ToString()}";
            _moneyCounterPreviosFrame = _playerResourceStorage.Money;
        }
        
    }
}
