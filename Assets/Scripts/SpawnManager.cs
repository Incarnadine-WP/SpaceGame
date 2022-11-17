using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private GameObject _boss;

    private GameManager _gameManager;
    private PauseMenu _pauseMenu;

    private float spawnX = 8;
    private int _bossCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        _pauseMenu.isGameActive = true;

        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        SpawnBoss();
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnX, spawnX), -3, -1);

        return spawnPosition;
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSec = new WaitForSeconds(2f);
        while (_bossCount == 0)
        {
            yield return waitForSec;
            int index = Random.Range(0, _enemyPrefabs.Count);

            Instantiate(_enemyPrefabs[index], RandomSpawnPosition(), _enemyPrefabs[index].transform.rotation);
        }
    }

    private void SpawnBoss()
    {
        StopCoroutine(SpawnEnemies());
        if(_gameManager.score >= 30 && _bossCount == 0)
        {
            _bossCount++;
            Instantiate(_boss, RandomSpawnPosition(), _boss.transform.rotation);
        }
    }

}
