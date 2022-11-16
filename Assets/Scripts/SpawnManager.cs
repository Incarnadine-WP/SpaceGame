using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;

    private PauseMenu _pauseMenu;

    private float spawnX = 8;

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        _pauseMenu.isGameActive = true;

        StartCoroutine(SpawnEnemies());
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnX, spawnX), -3, -1);

        return spawnPosition;
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSec = new WaitForSeconds(2f);
        while (_pauseMenu.isGameActive)
        {
            yield return waitForSec;
            int index = Random.Range(0, _enemyPrefabs.Count);

            Instantiate(_enemyPrefabs[index], RandomSpawnPosition(), _enemyPrefabs[index].transform.rotation);
        }
    }
}
