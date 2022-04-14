using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   [SerializeField] private Button Reset;
   [SerializeField] private Button SpeedUpButton;
   public PlayerScriptableObject playerData;

   private void Start()
   {
      Reset.onClick.AddListener(Restart);
      SpeedUpButton.onClick.AddListener(SpeedUp);
   }

   private void Restart()
   {
      SceneManager.LoadScene("Main");
   }

   private void SpeedUp() => playerData.Speed.x += 0.02f;
}
