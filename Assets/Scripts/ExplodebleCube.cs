using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class ExplodebleCube : MonoBehaviour 
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _divisionChange = 100.0f;

    public Rigidbody RigidBody => _rigidbody;
    public Material Material => _renderer.material;
    public float DivisionChange => _divisionChange;

    public void Initialize(float newSplitChange)
    {
        _divisionChange = newSplitChange; 
    }
}
