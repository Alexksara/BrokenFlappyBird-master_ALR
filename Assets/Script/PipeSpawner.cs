using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public Transform startSpawn;
    public List<GameObject> pipes;

    [SerializeField] private float M_spawnRate = 1f;
    [SerializeField] private float M_randomRange = 1f;

    private float M_timer = float.MaxValue;

    void Update()
    {
        M_timer += Time.deltaTime;
        if (M_timer >= M_spawnRate)
        {
            SpawnPipes();
            M_timer = 0f;
        }
    }

    public void StartSpawning()
    {
        enabled = true;
    }

    void SpawnPipes()
    {
        float yOffset = Random.Range(-M_randomRange, M_randomRange);
        Vector3 spawnPosition = startSpawn.position + Vector3.up * yOffset;
        pipes.Add(Instantiate(pipePrefab, spawnPosition, Quaternion.identity));
    }
}
