using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs
    [SerializeField] private PathCreator[] paths;       // Array of paths

    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns
    [SerializeField] private int enemiesPerWave = 5;   // Number of enemies per wave

    private int _randomEnemyIndex;
    private int _randomPathIndex;
    private PathCreator _chosenPath;
    private void Start()
    {
        StartCoroutine(SpawnWave()); 
    }

    private IEnumerator SpawnWave()
    {
        while (true) // Continue spawning waves indefinitely
        {
            _randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            _randomPathIndex = Random.Range(0, paths.Length);
            
            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy(_randomEnemyIndex, _randomPathIndex); // Spawn an enemy
                yield return new WaitForSeconds(spawnInterval); // Wait for a duration before the next enemy spawn
            }

            yield return new WaitForSeconds(spawnInterval); // Wait before starting the next wave
        }
    }

    private void SpawnEnemy(int randomEnemyIndex,int randomPathIndex)
    {
        _chosenPath = paths[randomPathIndex];
        var transform1 = transform;
        GameObject newEnemy = Instantiate(enemyPrefabs[randomEnemyIndex], transform1.position, Quaternion.identity);

        PathFollower pathFollower = newEnemy.GetComponent<PathFollower>();
        pathFollower.SetPath(_chosenPath);
    }
}