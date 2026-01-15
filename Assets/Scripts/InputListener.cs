using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private int _valueButtonForClick = 0;

    public event Action LeftMouseClicked;

    private void Update()
    {
        ListenMouseLeftClick();
    }

    private void ListenMouseLeftClick()
    {
        if (Input.GetMouseButtonDown(_valueButtonForClick))
        {
            LeftMouseClicked?.Invoke();
        }
    }
}
