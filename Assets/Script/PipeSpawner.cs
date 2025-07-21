using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public float randomRange = 1f;
    public Transform startSpawn;
    public List<GameObject> pipes;
    
    private float M_timer = float.MaxValue;

    void Update()
    {
        M_timer += Time.deltaTime;
        if (M_timer >= spawnRate)
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
        float yOffset = Random.Range(-randomRange, randomRange);
        Vector3 spawnPosition = startSpawn.position + Vector3.up * yOffset;
        pipes.Add(Instantiate(pipePrefab, spawnPosition, Quaternion.identity));
    }
}
