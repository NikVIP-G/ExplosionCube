using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 20;
    [SerializeField] private float _explosionRadius = 3;

    public void OnExplosion(ExplodebleCube cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<ExplodebleCube> _explodebleCubes = new List<ExplodebleCube>();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<ExplodebleCube>(out ExplodebleCube explodebleCube))
                collider.attachedRigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }
}
