using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;

    public event Action<ExplodebleCube> CubeHit;

    private void OnEnable()
    {
        _inputListener.OnClicked += OnLeftMouseClicked;
    }

    private void OnDisable()
    {
        _inputListener.OnClicked -= OnLeftMouseClicked;
    }

    private void OnLeftMouseClicked()
    {
        RayCast();
    }

    private void RayCast()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(currentMousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<ExplodebleCube>(out ExplodebleCube cube))
                CubeHit?.Invoke(cube);
        }
    }
}
