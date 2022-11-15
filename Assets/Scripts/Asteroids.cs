using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private AudioClip _asteroidDestroyedSound;
    [SerializeField] private ParticleSystem _explosionAsteroid;

    private GameManager _gameManager;

    private AudioSource _audio;
    private Rigidbody _enemyRB;

    private int _lives;
    private float _maxSpeed = 7f;
    private float _minSpeed = 1f;
    private float _maxTorque = 10f;

    
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audio = GameObject.Find("Camera").GetComponent<AudioSource>();
        _enemyRB = GetComponent<Rigidbody>();
        AsteroidsMove();
        EnemyTorque();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Destroy(collision.gameObject);
            _gameManager.UpdateLives();
            print("Game Over");
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            _audio.PlayOneShot(_asteroidDestroyedSound, 0.5f);
            collision.gameObject.SetActive(false);
            print("Asteroid destroyed!");
            Destroy(gameObject);
            Instantiate(_explosionAsteroid, transform.position, _explosionAsteroid.transform.rotation);
        }
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    // adding rotation of asteroids
    private void EnemyTorque()
    {
        _enemyRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.VelocityChange);
    }

    private Vector3 RandomSpeed()
    {
        return Vector3.down * Random.Range(_minSpeed, _maxSpeed);
    }

    // adding moving of asteroids
    private void AsteroidsMove()
    {
        _enemyRB.AddForce(RandomSpeed(), ForceMode.Impulse);
    }
    
}
