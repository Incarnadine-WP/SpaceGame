using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;

    private float spawnX = 8;
    private bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemies());
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnX, spawnX), -3, -1);

        return spawnPosition;
    }

    private IEnumerator SpawnEnemies()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2f);
            int index = Random.Range(0, _enemyPrefabs.Count);

            Instantiate(_enemyPrefabs[index], RandomSpawnPosition(), _enemyPrefabs[index].transform.rotation);
        }
        
    }
}
