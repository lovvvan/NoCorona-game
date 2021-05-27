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

    //Spawn the enemies by randomising a spawn location and an enemy type
    //Then it adds this random enemy and the random spawn zone to the enemy list and the game
    private void SpawnEnemy()
    {
        while (enemiesSpawned < maxSpawn)
        {
            typeClose = false;
            enemyType = UnityEngine.Random.Range(0, enemyPrefabs.Length); // Grabs a random number
            spawnPoint.x = UnityEngine.Random.Range(halfWidth * 2.6f, 200);
            spawnPoint.y = UnityEngine.Random.Range(3.7f, 5.45f);
            spawnPoint.z = 0;
            foreach (Transform neighbor in enemies)
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
            
            if (!typeClose)
            {
                triedSpawns = 0;
                GameObject go = Instantiate(enemyPrefabs[enemyType], spawnPoint, Quaternion.identity, enemies);
                enemiesSpawned++;
            }
            else
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
