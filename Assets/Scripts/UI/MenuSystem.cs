using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


[System.Serializable]
public class MenuSettings
{
    public string Name;
    public UnityEvent Callback;
}

[RequireComponent(typeof(UIDocument))]
public class MenuSystem : MonoBehaviour
{
    [SerializeField] private List<MenuSettings> _settings;
    [SerializeField] private float _duration;
    [SerializeField] private EasingMode _easing;
    [SerializeField] private float _buttonDelay;
    [SerializeField] private VisualTreeAsset _buttonTemplate;
    private VisualElement _buttonContainer;
    void Start()
    {
        StartCoroutine(CreateSettingsMenu());
       
        
    }

    private IEnumerator CreateSettingsMenu()
    {
        _buttonContainer = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("settings-container");
        _buttonContainer.SetEnabled(true);
        foreach (var settingButton in _settings)
        {
            VisualElement newButton = _buttonTemplate.CloneTree();
            UnityEngine.UIElements.Button button = newButton.Q<UnityEngine.UIElements.Button>("button");
            _buttonContainer.Add(newButton);
            yield return new WaitForSeconds(_duration);
        }
        _buttonContainer.SetEnabled(false);
    }

}
