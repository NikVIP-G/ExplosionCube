using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionCube : MonoBehaviour
{
    [SerializeField] private ExplodebleCube _prefabeExplodebleCube;
    [SerializeField] private ColorChanger _colorChanger;

    [SerializeField] private float _explosionForce = 100;
    [SerializeField] private float _explosionRadius = 1;

    public void SpawnCube(int amount, ExplodebleCube cube)
    {
        Vector3 spawnScale = cube.transform.localScale / 2;
        float newDivisionChance = cube.DivisionChange / 2;

        for (int i = 0; i < amount; i++)
        {
            ExplodebleCube newCube = Instantiate(_prefabeExplodebleCube);

            newCube.Initialize(newDivisionChance);
            SetTransfromValue(cube, newCube, spawnScale);
            _colorChanger.ChangeColorToRandom(newCube.Material);
            AddExplosionForceForSpawnedCube(newCube, cube.transform.position);
        }
    }

    private void AddExplosionForceForSpawnedCube(ExplodebleCube spawnedCube, Vector3 positionExplosion)
    {
        spawnedCube.RigidBody.AddExplosionForce(_explosionForce, positionExplosion, _explosionRadius);
    }

    private void SetTransfromValue(ExplodebleCube origin, ExplodebleCube target, Vector3 scale)
    {
        SetScale(target, scale);
        SetRandomPosition(origin, target, scale.x);
    }

    private void SetScale(ExplodebleCube target, Vector3 scale)
    {
        target.transform.localScale = scale;
    }

    private void SetRandomPosition(ExplodebleCube originCube, ExplodebleCube newCube, float scale)
    {
        Vector3 randomDirection = Random.insideUnitSphere;
        Vector3 randomOffset = randomDirection * scale;
        Vector3 spawnPosition = originCube.transform.position + randomOffset;

        newCube.transform.position = spawnPosition;
    }
}
