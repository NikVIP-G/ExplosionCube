using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DivisionCube))]
[RequireComponent (typeof(ColorChanger))]
[RequireComponent (typeof(Explosion))]

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _rayCaster;
    [SerializeField] private DivisionCube _division;
    [SerializeField] private Explosion _explosion;

    [SerializeField] private int _minDivisionAmout = 2;
    [SerializeField] private int _maxDivisionAmout = 6;

    private int _divisionChanceMin = 1;
    private int _divisionChanceMax = 100;

    private void OnEnable()
    {
        _rayCaster.CubeHit += OnCubeHit;
    }

    private void OnDisable()
    {
        _rayCaster.CubeHit -= OnCubeHit;
    }

    private void OnCubeHit(ExplodebleCube cubeHit)
    {
        if (TryDivision(cubeHit.DivisionChange))
        {
            _division.SpawnCube(GetCurrentAmountCubeForSpawn(), cubeHit);
            _explosion.OnExplosion(cubeHit);
            Destroy(cubeHit.gameObject);
        }
        else
        {
            Destroy(cubeHit.gameObject);
        }
    }

    private bool TryDivision(float divisionChance)
    {
        return Random.Range(_divisionChanceMin, _divisionChanceMax) <= divisionChance;
    }

    private int GetCurrentAmountCubeForSpawn()
    {
        return Random.Range(_minDivisionAmout, _maxDivisionAmout + 1);
    }
}
