using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private GameObject _enemybullet;

    private GameManager _gameManager;
    private AudioSource _audio;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _audio = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
        StartCoroutine(EnemyFire());
    }

    private IEnumerator EnemyFire()
    {
        var waitTimer = new WaitForSeconds(1f);

        while (_gameManager.currentLives >= 1)
        {
            yield return waitTimer;
            _audio.PlayOneShot(_fireSound, 0.2f);

            Instantiate(_enemybullet, transform.position, Quaternion.Euler(0, 0, 180)); // create and turn bullet on 180 degrees to point towards the player
        }
    }
}



