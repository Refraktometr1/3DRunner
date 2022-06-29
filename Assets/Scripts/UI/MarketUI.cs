using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MarketUI : MonoBehaviour
{
   public VisualTreeAsset CarPrefabTemplate;
   private CarModelsScriptable CarModels;
   private VisualElement _root;
   private VisualElement _carButtonsContainer;
   private VisualElement _carButton;
   
   

   private void Start()
   {
      CarModels = Resources.Load<CarModelsScriptable>("CarModels");
      _root = gameObject.GetComponent<UIDocument>().rootVisualElement;
      _carButtonsContainer  = _root.Q<VisualElement>("CarButtonsContainer");
      VisualElement _template = CarPrefabTemplate.CloneTree();
      
      _carButton = _template.Q<VisualElement>("CarTemplate");
      _carButtonsContainer.Add(_carButton);
   }

   private void CarButtonCreater()
   {
      
   }
}
