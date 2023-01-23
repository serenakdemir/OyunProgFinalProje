using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    public Collectable prefab;
    public List<Collectable> spawnedPrefab = new List<Collectable>();
    public int maxSpawnCount = 10;
    public float spawnRadius = 10;
    public float spawnPeriod = 2f;
    private float nextSpawnTime = 0;
    void Update()
    {
        HandleNullElements();
        if (spawnedPrefab.Count >= maxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        var circlePos = Random.insideUnitCircle; 
        Vector3 spawnPosition = new Vector3(circlePos.x, 0.06f, circlePos.y) * spawnRadius;
        spawnPosition += transform.position;
        var collectable = Instantiate(prefab, null);
        collectable.transform.position = spawnPosition;
        spawnedPrefab.Add(collectable);

    }

    private void HandleNullElements()
    {
        for (int i = spawnedPrefab.Count - 1; i >= 0; i--)
        {
            if (spawnedPrefab[i] == null)
            {
                spawnedPrefab.RemoveAt(i);
            }
        }

    }
}
