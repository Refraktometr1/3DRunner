using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SettingsButton : MonoBehaviour
{
  public VisualElement root;
  private VisualElement _settingsContainer;
  private VisualElement _pupUpContainer;
  
  private UnityEngine.UIElements.Button _settingsButton;
  private UnityEngine.UIElements.Button _speedUpButton;
  private UnityEngine.UIElements.Button _restartButton;
  
  private UnityEngine.UIElements.Button _soundButton;
  private UnityEngine.UIElements.Button _musicButton;
  private UnityEngine.UIElements.Button _vibrationButton;
  
  private UnityEngine.UIElements.ProgressBar _resourceProgressBar; 
  public PlayerScriptableObject PlayerData;
  public PlayerResourceStorage ResourceStorage;
  private AudioResources _audioResources;
  private Color _greenColor; 
  private Color _grayColor; 
  

  private void Awake()
  {
    ColorUtility.TryParseHtmlString("#59C251", out _greenColor);
    ColorUtility.TryParseHtmlString("#767676", out _grayColor);
  }

  private void OnEnable()
  {
    _audioResources =  Resources.Load<AudioResources>("AudioResources");
    root = gameObject.GetComponent<UIDocument>().rootVisualElement;
    _speedUpButton  = root.Q<UnityEngine.UIElements.Button>("SpeedUP");
    _restartButton  = root.Q<UnityEngine.UIElements.Button>("Restart");
    _settingsButton = root.Q<UnityEngine.UIElements.Button>("Settings");
    _soundButton = root.Q<UnityEngine.UIElements.Button>("sound-button");
    _musicButton = root.Q<UnityEngine.UIElements.Button>("music-button");
    _vibrationButton = root.Q<UnityEngine.UIElements.Button>("vibration-button");
    
    _settingsContainer = root.Q<VisualElement>("setting-container");
    _pupUpContainer = root.Q<VisualElement>("PupUp");
    _pupUpContainer.style.display = DisplayStyle.None;
    
    _speedUpButton.RegisterCallback<ClickEvent>(evt => SpeedUp());
    _restartButton.RegisterCallback<ClickEvent>(evt => RestartScene());
    _settingsButton.RegisterCallback<ClickEvent>(ev => OpenClosePanel(_settingsContainer));
    
    _soundButton.RegisterCallback<ClickEvent>(ev => SoundSettings());
    _musicButton.RegisterCallback<ClickEvent>(ev => MusicSettings());
    _vibrationButton.RegisterCallback<ClickEvent>(ev => VibrationSettings());
    
    _pupUpContainer.RegisterCallback<ClickEvent>((e) =>
    {
      e.StopImmediatePropagation();
      OpenClosePanel(_pupUpContainer);
    });
    
    _resourceProgressBar = root.Q<UnityEngine.UIElements.ProgressBar>("CapacityResources");
    _resourceProgressBar.value = ResourceStorage.Money;
    _resourceProgressBar.title = ResourceStorage.Money.ToString();

    _settingsContainer.style.display = DisplayStyle.None;
  }

  private void VibrationSettings()
  {
    Vibration.Vibrate(30,100,true);
    Vibration.isVibrationOff = !Vibration.isVibrationOff;
    SwitchButton(_vibrationButton, Vibration.isVibrationOff);
  }
  
  private void MusicSettings()
  {
    bool isMusicOff = AudioManager.Instanse.MusicOff();
    SwitchButton(_musicButton, isMusicOff);
  }
  
  private void SoundSettings()
  {
    AudioManager.Instanse.PlaySound(_audioResources.ClickButton);
    AudioManager.Instanse.isSoundOff = !AudioManager.Instanse.isSoundOff;
    SwitchButton(_soundButton,  AudioManager.Instanse.isSoundOff);
  }

  private void SwitchButton(UnityEngine.UIElements.Button button, bool isOn)
  {
    AudioManager.Instanse.PlaySound(_audioResources.ClickButton);
    Vibration.Vibrate(30,100,true);
    if (isOn)
    {
      button.style.justifyContent = new StyleEnum<Justify>(Justify.FlexEnd);
      button.style.backgroundColor = new StyleColor(_grayColor);                     
    }
    else
    {
      button.style.justifyContent = new StyleEnum<Justify>(Justify.FlexStart);
      button.style.backgroundColor = new StyleColor(_greenColor);
    }
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
    AudioManager.Instanse.PlaySound(_audioResources.ClickButton);
    Vibration.Vibrate(30,100,true);
    PlayerData.Speed.z += 0.02f;
  }

  private void RestartScene()
  {
    AudioManager.Instanse.PlaySound(_audioResources.ClickButton);
    SceneManager.LoadScene("Main");
  }

  private void OpenClosePanel(VisualElement panel)
  {
    AudioManager.Instanse.PlaySound(_audioResources.ClickButton);
    bool isEnable = panel.style.display == DisplayStyle.Flex; 
    if (isEnable)
    {
      StartCoroutine(SetNormalTime());
    }
    else
    {
      Time.timeScale = 0f;
    }
    panel.style.display = isEnable ? DisplayStyle.None : DisplayStyle.Flex;
  }

 

  private IEnumerator SetNormalTime()
  {
    yield return new WaitForSecondsRealtime(0.5f);
    Time.timeScale = 1f;
  }
}
