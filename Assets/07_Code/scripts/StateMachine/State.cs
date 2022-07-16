using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class State : MonoBehaviour
{
    [NonSerialized]public string myID ="";

    public virtual void Enter() { }
    public virtual void Functionality() { }
    public virtual void Exit() { }
    public virtual string CheckTransitions() { return ""; }
}
