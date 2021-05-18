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

    private void Update()
    {
        SpawnEnemies();
    }


    private void SpawnEnemies()
    {
        // You do -1 because arrays and listsstart at zero but if your array is only 1 long and you have Random.Range(0, spawnZones.Length) it would be (0, 1) because the length is 1 gameobject long.
        int spawnNum;
        int enemyNum;

        //Here is where you spawn your enemies, you could spawn heaps of them by using enemyList.Add(enemyPrefabs[enemyNum], spawnZones[spawnNum], Quaternion.identiy); over and over, but you could use
        //A While loop and have a maximum spawn number like so; (I added maxSpawn, change it to whatever number in the inspector)

        while(enemyList.Count < maxSpawn)
        {
            spawnNum = Random.Range(0, spawnZones.Length - 1); // Grabs a random number
            enemyNum = Random.Range(0, enemyPrefabs.Length - 1); // Grabs a random number
            enemyList.Add(Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform));
        }


    }
  }
