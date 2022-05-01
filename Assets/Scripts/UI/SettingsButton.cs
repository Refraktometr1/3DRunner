using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SettingsButton : MonoBehaviour
{
  public VisualElement root;
  private VisualElement _settingsContainer;
  private UnityEngine.UIElements.Button _settingsButton;
  private UnityEngine.UIElements.Button _speedUpButton;
  private UnityEngine.UIElements.Button _restartButton;
  private UnityEngine.UIElements.ProgressBar _resourceProgressBar; 
  public PlayerScriptableObject PlayerData;
  public PlayerResourceStorage ResourceStorage;
  private RadioButton _radioButton;
  
  private void OnEnable()
  {
    root = gameObject.GetComponent<UIDocument>().rootVisualElement;
    _speedUpButton  = root.Q<UnityEngine.UIElements.Button>("SpeedUP");
    _restartButton  = root.Q<UnityEngine.UIElements.Button>("Restart");
    _settingsButton = root.Q<UnityEngine.UIElements.Button>("Settings");
    _settingsContainer = root.Q<VisualElement>("setting-container");
    
    _speedUpButton.RegisterCallback<ClickEvent>(evt => SpeedUp());
    _restartButton.RegisterCallback<ClickEvent>(evt => RestartScene());
    _settingsButton.RegisterCallback<ClickEvent>(ev => OpenSettings());
    
    _resourceProgressBar = root.Q<UnityEngine.UIElements.ProgressBar>("CapacityResources");
    _resourceProgressBar.value = ResourceStorage.Money;
    _resourceProgressBar.title = ResourceStorage.Money.ToString();
  }
  
  private void Update()
  {
    if ((int)_resourceProgressBar.value != ResourceStorage.Money)
    {
      _resourceProgressBar.value = ResourceStorage.Money;
      _resourceProgressBar.title = ResourceStorage.Money.ToString();
    }
  }

  private void SpeedUp()
  {
    Vibration.Vibrate(30,100,true);
    PlayerData.Speed.z += 0.02f;
  }

  private void RestartScene()
  {
    SceneManager.LoadScene("Main");
  }

  private void OpenSettings()
  {
    _settingsContainer.style.display = _settingsContainer.style.display ==DisplayStyle.Flex ? DisplayStyle.None : DisplayStyle.Flex;
    Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
  }
 
}
