using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MarketUI : MonoBehaviour
{
   public VisualTreeAsset CarPrefabTemplate;
   private PlayerCarsData _playerCarsData;
   private VisualElement _root;
   private VisualElement _carButtonsContainer;
   private VisualElement _carButton;
   
   

   private void Start()
   {
      _playerCarsData = Resources.Load<PlayerCarsData>("PlayerCarsData");
      _root = gameObject.GetComponent<UIDocument>().rootVisualElement;
      _carButtonsContainer  = _root.Q<VisualElement>("CarButtonsContainer");

      for (int i = 1; i < _playerCarsData.Data.Count; i++)
      {
         VisualElement _template = CarPrefabTemplate.CloneTree();
         _carButton = _template.Q<VisualElement>("CarTemplate");
         _carButtonsContainer.Add(_carButton);
         _carButton.style.backgroundImage = new StyleBackground(_playerCarsData.Data[i].imageUI);
      }
   }

   private void CarButtonCreater()
   {
      
   }
}
