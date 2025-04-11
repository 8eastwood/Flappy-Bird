using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _shootKey = KeyCode.E;
    
    public event Action ShotFired;
    public event Action WingFlapped;
    
    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            ShotFired?.Invoke();
        }

        if (Input.GetKeyDown(_jumpKey))
        {
            WingFlapped?.Invoke();
        }
    }
}
