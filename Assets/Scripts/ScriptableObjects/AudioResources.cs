using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "AudioResources", menuName = "ScriptableObjects/AudioResources")]

public class AudioResources : ScriptableObject
{
    public AudioClip Hit;
    public AudioClip Die;
    public AudioClip ClickButton;
    public AudioClip PickCoin;
    public AudioClip PickBooster;

}