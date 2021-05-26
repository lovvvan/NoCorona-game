using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform enemies;

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxSpawn;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;
    private Vector3 spawnPoint;
    private Vector3 camPos;
    private bool typeClose;
    private int trySpawn;

    int chanceOfSpawn;

    private void Start()
    {
        theCamera = CameraController.MyInstance.GetCamera();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        SpawnEnemy();
    }

    //Calls SpawnEnemies once per frame
    private void Update()
    {
        //chanceOfSpawn = Random.Range(0, 1000);
        //Invoke("SpawnEnemy", chanceOfSpawn);
        //camPos = theCamera.transform.position;
        //Debug.Log("camPos");
        //Debug.Log(camPos);
    }

    //Spawn the enemies by randomising a spawn location and an enemy type
    //Then it adds this random enemy and the random spawn zone to the enemy list and the game
    private void SpawnEnemy()
    {
        int enemyType;

        while (enemyList.Count < maxSpawn)
        {
            //spawnNum = Random.Range(0, spawnZones.Length - 1); // Grabs a random number
            spawnPoint.x = Random.Range(halfWidth * 2.5f, 200);
            spawnPoint.y = Random.Range(halfHeight - 0.3f, halfHeight + 1.45f);
            spawnPoint.z = 0;
            typeClose = false;
            enemyType = Random.Range(0, enemyPrefabs.Length); // Grabs a random number
            foreach (GameObject neighbor in enemyList)
            {
                Debug.Log((neighbor.GetComponent<Enemy>()).prefabID);
                if (enemyType == (neighbor.GetComponent<Enemy>()).prefabID)
                {
                    Debug.Log(Vector3.Distance(spawnPoint, neighbor.transform.position));
                   if (Vector3.Distance(spawnPoint, neighbor.transform.position) < 2)
                   {
                        typeClose = true;
                        trySpawn++;
                        if (trySpawn >= 100000)
                        {
                            break;
                        }
                    }
                }
            }
            
            if (!typeClose)
            {
                trySpawn = 0;
                GameObject go = Instantiate(enemyPrefabs[enemyType], spawnPoint, Quaternion.identity);
                go.transform.parent = enemies;
                enemyList.Add(go);
            }
            
        }


    }
  }
