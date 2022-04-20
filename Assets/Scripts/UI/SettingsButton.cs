using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SettingsButton : MonoBehaviour
{
  //public VisualElement Settings;
  public VisualElement root;
  private UnityEngine.UIElements.Button Settings;
  
  private void OnEnable()
  {
    root = GetComponent<UIDocument>().rootVisualElement;
    Settings = root.Q<UnityEngine.UIElements.Button>("Settings");
    // ReSharper disable once HeapView.CanAvoidClosure
    Settings.RegisterCallback<ClickEvent>(evt => OpenSettingsMenu());
  }

  private void OpenSettingsMenu()
  {
    Settings.text = "AAA";
  }
}
