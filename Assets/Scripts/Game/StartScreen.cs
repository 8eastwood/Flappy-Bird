 using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;
    
    protected override void OnButtonClick()
    {
        Debug.Log("OnButtonClick");
        PlayButtonClicked?.Invoke();
    }

    public override void Open()
    {
       WindowGroup.alpha = 1f;
       ActionButton.interactable = true;
    }

    public override void Close()
    {
       WindowGroup.alpha = 0f;
       ActionButton.interactable = false;
    }
}
