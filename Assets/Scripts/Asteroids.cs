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

    private float _maxSpeed = 6f;
    private float _minSpeed = 2f;
    private float _maxTorque = 6f;


    private void Start()
    {

        _pauseMenu = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _audio = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
        _enemyRB = GetComponent<Rigidbody>();

        AsteroidsMove();
        AsteroidsTorque();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.UpdateLives();
            _audio.PlayOneShot(_asteroidDestroyedSound, 1f);
            Destroy(gameObject);
            Instantiate(_explosionAsteroid, transform.position, _explosionAsteroid.transform.rotation);

            if (_gameManager.currentLives <= 0)
            {
                Destroy(collision.gameObject);
                Instantiate(_player.playerDestroyed, transform.position, _player.playerDestroyed.transform.rotation);
                print("Game Over");
                _pauseMenu.GameOver();
            }
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            _audio.PlayOneShot(_asteroidDestroyedSound, 1f);
            _gameManager.UpdateScore(10);
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
    private void AsteroidsTorque()
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
