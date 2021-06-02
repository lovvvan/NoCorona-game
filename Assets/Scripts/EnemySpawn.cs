using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform enemies;

    [SerializeField]
    private int maxSpawn;

    [SerializeField]
    private float closestDistance;

    [SerializeField]
    private int maxSpawnTries;

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;
    private Vector3 spawnPoint;
    private int enemyType;
    private bool typeClose;
    private int triedSpawns;
    private int enemiesSpawned;

    private void Start()
    {
        theCamera = CameraController.MyInstance.GetCamera();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        SpawnEnemy();
    }

    private void Update()
    {

    }

    // Spawn the enemies by randomising a spawn location and an enemy type
    // Then it adds this random enemy and the random spawn zone to the enemy list and the game
    private void SpawnEnemy()
    {
        while (enemiesSpawned < maxSpawn)
        {
            typeClose = false;
            enemyType = UnityEngine.Random.Range(0, enemyPrefabs.Length);   // Grabs a random number for specific enemiy prefabs
            spawnPoint.x = UnityEngine.Random.Range(halfWidth * 2.6f, 200); // Defines the spawn area for enemies in x,
            spawnPoint.y = UnityEngine.Random.Range(3.7f, 5.45f);           // y,
            spawnPoint.z = 0;                                               // and z
            foreach (Transform neighbor in enemies)     // Checks if there are any enemies of the same type (i.e. with the same speed) in the proximity of the proposed spwan point
            {
                if (enemyType == (neighbor.gameObject.GetComponent<Enemy>()).prefabID)
                {
                    if (Vector3.Distance(spawnPoint, neighbor.gameObject.transform.position) < closestDistance)
                    {
                        typeClose = true;
                        break;
                    }
                }
            }
            
            if (!typeClose) // If no enemies of same type are to close, the enemy is spawned
            {
                triedSpawns = 0;
                GameObject go = Instantiate(enemyPrefabs[enemyType], spawnPoint, Quaternion.identity, enemies);
                enemiesSpawned++;
            }
            else            // Otherwise, a new spawn is attempted, unless too many consecutive failed attempts have been made, in which case spawning of enemies is discontinued
            {
                triedSpawns++;
                if (triedSpawns > maxSpawnTries)
                {
                    break;
                }
            }
            
        }


    }
  }
