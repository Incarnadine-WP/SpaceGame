using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private AudioClip _asteroidDestroyedSound;
    [SerializeField] private ParticleSystem _explosionAsteroid;

    private GameManager _gameManager;
    private Player _player;
    private PauseMenu _pauseMenu;

    private AudioSource _audio;
    private Rigidbody _enemyRB;

    private int _lives;
    private float _maxSpeed = 7f;
    private float _minSpeed = 1f;
    private float _maxTorque = 10f;


    private void Start()
    {
        _pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        _player = GameObject.Find("Player").GetComponent<Player>();
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
            Destroy(gameObject);
            Instantiate(_explosionAsteroid, transform.position, _explosionAsteroid.transform.rotation);

            if (_gameManager.currentLives <= 0)
            {
                Destroy(collision.gameObject);
                Instantiate(_player._playerDestroyed, transform.position, _explosionAsteroid.transform.rotation);
                print("Game Over");
                _pauseMenu.GameOver();
            }
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            _audio.PlayOneShot(_asteroidDestroyedSound, 0.5f);
            collision.gameObject.SetActive(false);
            print("Asteroid destroyed!");
            Destroy(gameObject);
            Instantiate(_explosionAsteroid, transform.position, _explosionAsteroid.transform.rotation);
            _gameManager.UpdateScore(10);
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
