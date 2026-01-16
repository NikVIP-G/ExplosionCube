using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private int _valueButtonForClick = 0;

    public event Action OnClicked;

    private void Update()
    {
        ListenOnClick();
    }

    private void ListenOnClick()
    {
        if (Input.GetMouseButtonDown(_valueButtonForClick))
            OnClicked?.Invoke();
    }
}
