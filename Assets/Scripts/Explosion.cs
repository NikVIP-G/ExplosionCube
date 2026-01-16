using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 200;
    [SerializeField] private float _baseExplosionRadius = 5;

    private ForceMode _forceMode => ForceMode.VelocityChange;

    public void Explode(List<ExplodebleCube> spawnedCubes, ExplodebleCube originCube)
    {
        if (spawnedCubes != null)
            AddExplosionForceForSpawnedCube(spawnedCubes, originCube);
        else
            ExplosionCubesInRadius(originCube);

        DestroyCube(originCube);
    }

    private void AddExplosionForceForSpawnedCube(List<ExplodebleCube> spawnedCubes, ExplodebleCube originCube)
    {
        foreach (ExplodebleCube cube in spawnedCubes)  
            Push(cube, originCube.transform.position);
    }

    private void Push(ExplodebleCube cube, Vector3 pointEpicenter)
    {
        Vector3 direction = cube.transform.position - pointEpicenter;
        direction.Normalize();
        cube.RigidBody.AddForce(direction, _forceMode);
    }

    private void DestroyCube(ExplodebleCube originCube)
    {
        originCube.gameObject.SetActive(false);
        Destroy(originCube.gameObject);
    }

    public void ExplosionCubesInRadius(ExplodebleCube cube)
    {
        Vector3 explosionEpicenter = cube.transform.position;
        float scaleOriginCube = cube.transform.localScale.x;

        float explotionForce = _baseExplosionForce / scaleOriginCube;
        float explotionRadius = _baseExplosionRadius / scaleOriginCube;

        Collider[] colliders = Physics.OverlapSphere(explosionEpicenter, explotionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<ExplodebleCube>(out ExplodebleCube explodebleCube) & explodebleCube != cube)
            {
                int maxForceMultiplier = 1;

                float distance = Vector3.Distance(explodebleCube.transform.position, explosionEpicenter);
                float forceMultiplier = maxForceMultiplier - (distance / explotionRadius);

                explodebleCube.RigidBody.AddExplosionForce(explotionForce * forceMultiplier, explosionEpicenter, explotionRadius);
            }
        }
    }
}
