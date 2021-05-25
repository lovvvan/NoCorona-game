using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnZones; // Array filled with spawn zones transform

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxSpawn;


    private void Start()
    {

    }

    //Calls SpawnEnemies once per frame
    private void Update()
    {
        SpawnEnemies();
    }

    //Spawn the enemies by declaring the spawn zone number and the enemy number
    //Then sets these to random numbers within their respective ranges
    //Then it adds this random enemy and the random spawn zone to the enemy list and the game
    private void SpawnEnemies()
    {
        int spawnNum;
        int enemyNum;

        while(enemyList.Count < maxSpawn)
        {
            spawnNum = Random.Range(0, spawnZones.Length - 1); // Grabs a random number
            enemyNum = Random.Range(0, enemyPrefabs.Length - 1); // Grabs a random number
            enemyList.Add(Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform));
        }


    }
  }
