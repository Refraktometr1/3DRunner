using UnityEngine;
using UnityEngine.UIElements;

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

      for (int i = 0; i <  _playerCarsData.Materials.Count; i++)
      {
         VisualElement _template = CarPrefabTemplate.CloneTree();
         _carButton = _template.Q<VisualElement>("CarTemplate");
         _carButtonsContainer.Add(_carButton);
         var a =  _playerCarsData.Materials[i].color;
         
         _carButton.style.backgroundColor = a;
         _carButton.name = i.ToString();
      }
   }

   private void CarButtonCreater()
   {
      
   }
}
