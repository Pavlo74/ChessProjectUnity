using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputHandler : MonoBehaviour, InputHandler
{
    public void ProcessInput(Vector3 inputPosition, GameObject selected, Action callback)
    {
        callback.Invoke();
    }
}
