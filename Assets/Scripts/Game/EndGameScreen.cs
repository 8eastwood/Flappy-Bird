using System;
using UnityEngine;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
        gameObject.SetActive(false);
    }
}