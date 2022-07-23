using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
   public Vector3 Speed;

   private void OnEnable()
   {
      Load();
   }

   public void Save() => SaveLoadSystem.SaveData(this, name);
   public void Load() => SaveLoadSystem.LoadScriptableObject(name, this);
}
