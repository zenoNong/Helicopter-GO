using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int initialTerrainCount = 5;
    public float terrainHeight = 4f;
    public float terrainWidth = 10f;
    public GameObject[] terrainPrefab;
    private Transform helicopter;
    private float spawnZ;
    private Queue<GameObject> terrainQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        helicopter = GameObject.FindGameObjectWithTag("Player").transform;
        spawnZ = helicopter.position.x -15;
        for(int i = 0; i<initialTerrainCount; i++)
        {
            SpawnTerrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(helicopter.position.x + 2*terrainWidth> spawnZ)
        {
            SpawnTerrain();
            DestroyOldTerrain();
        }
        
    }

    void SpawnTerrain()
    {
        Vector2 spawnPosition = new Vector2(spawnZ + terrainWidth, Random.Range(terrainHeight +0.5f,terrainHeight-0.5f));
        GameObject newTerrain = Instantiate(terrainPrefab[Random.Range(0,terrainPrefab.Length)], spawnPosition, Quaternion.identity);
        terrainQueue.Enqueue(newTerrain);
        spawnZ += terrainWidth;
    }

    void DestroyOldTerrain()
    {
        GameObject oldTerrain = terrainQueue.Dequeue();
        Destroy(oldTerrain);
    }

}
