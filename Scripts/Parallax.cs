using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffectMultiplier = 0.4f;
    private Vector3 previousPosition;
    public int initialBackgroundCount = 5;
    private float backgroundWidth = 47f;
    public GameObject backgroundPrefabs;
    private Transform helicopter;
    private float spawnZ;
    private Queue<GameObject> backgroundQueue = new Queue<GameObject>();

    void Start()
    {
        helicopter = GameObject.FindGameObjectWithTag("Player").transform;
        previousPosition = helicopter.position;
        if (helicopter != null)
        {
            spawnZ = helicopter.position.x - (initialBackgroundCount / 2 * backgroundWidth)-20;
            for (int i = 0; i < initialBackgroundCount; i++)
            {
                SpawnBackground();
            }
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag assigned.");
        }
    }

    void Update()
    {
        if(helicopter != null)
        {
            Vector3 deltaMovement = helicopter.position - previousPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, 0, 0);
            previousPosition = helicopter.position;

            if (helicopter.position.x + 1.5 * backgroundWidth > spawnZ)
            {
                SpawnBackground();
                DestroyOldBackground();
            }

        }
        
    }

    void SpawnBackground()
    {
        Vector2 spawnPosition = new Vector2(spawnZ, transform.position.y);
        GameObject newBackground = Instantiate(backgroundPrefabs, spawnPosition, Quaternion.identity);
        backgroundQueue.Enqueue(newBackground);
        spawnZ += backgroundWidth;
    }

    void DestroyOldBackground()
    {
        GameObject oldBackground = backgroundQueue.Dequeue();
        Destroy(oldBackground);
    }
}
