using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MarketUI : MonoBehaviour
{
   private CarModelsScriptable CarModels;
   private VisualElement _root;
   private VisualElement _carButtonsContainer;
   private UnityEngine.UIElements.Button 
   
   

   private void Start()
   {
      CarModels = Resources.Load<CarModelsScriptable>("CarModels");
      _root = gameObject.GetComponent<UIDocument>().rootVisualElement;
      _carButtonsContainer  = root.Q<UnityEngine.UIElements.Button>("CarButtonsContainer");
   }

   private void CarButtonCreater()
   {
      
   }
}
