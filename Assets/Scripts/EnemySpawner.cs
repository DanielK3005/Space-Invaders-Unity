using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs
    [SerializeField] private PathCreator[] paths;       // Array of paths

    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns
    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval; 
    }

    private void Update()
    {
        // Decrease the timer
        timeSinceLastSpawn -= Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timeSinceLastSpawn <= 0f)
        {
            SpawnEnemy();
            timeSinceLastSpawn = spawnInterval; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length); // Choose a random enemy prefab
        int randomPathIndex = Random.Range(0, paths.Length); // Choose a random path index

        GameObject newEnemy = Instantiate(enemyPrefabs[randomEnemyIndex], transform.position, Quaternion.identity, transform);

        // Get the chosen path
        PathCreator chosenPath = paths[randomPathIndex];

        // Assign the path to the spawned enemy
        PathFollower pathFollower = newEnemy.GetComponent<PathFollower>();
        pathFollower.SetPath(chosenPath);
    }
}
