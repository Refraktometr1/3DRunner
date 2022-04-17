using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   [SerializeField] private Button Reset;
   [SerializeField] private Button SpeedUpButton;
   [SerializeField] private Button ExitButton;
   [SerializeField] private Button LoadButton;
   [SerializeField] private Text _text;
   public PlayerScriptableObject playerData;

   private void Start()
   {
      Reset.onClick.AddListener(Restart);
      SpeedUpButton.onClick.AddListener(SpeedUp);
      ExitButton.onClick.AddListener(Exit);
      LoadButton.onClick.AddListener(Load);
      
   }

   private void Restart()
   {
      SceneManager.LoadScene("Main");
   }

   private void SpeedUp() => playerData.Speed.x += 0.02f;

   private void Exit()
   {
      Application.Quit();
   }

   private void Load()
   {
      string namel = "PlayerData";
      var jsonData = File.ReadAllText($"{Application.persistentDataPath}/Save/{namel}.json");
      _text.text = jsonData;
   }
  
}
